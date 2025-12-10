using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quizmaster.Services;

namespace Quizmaster.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<QuizFileInfo> _availableQuizzes = new();

    [ObservableProperty]
    private QuizFileInfo? _selectedQuiz;

    [ObservableProperty]
    private ViewModelBase? _currentView;

    [ObservableProperty]
    private string _title = "Quizmaster - ArchiMate Quiz Application";

    public MainViewModel()
    {
        LoadAvailableQuizzes();
    }

    private void LoadAvailableQuizzes()
    {
        // Look for quiz files in the Quizzes directory next to the executable
        var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var quizzesDirectory = Path.Combine(appDirectory, "Quizzes");

        if (!Directory.Exists(quizzesDirectory))
        {
            // Try looking in the project directory for development
            quizzesDirectory = Path.Combine(appDirectory, "..", "..", "..", "..", "..", "Quizzes");
            if (!Directory.Exists(quizzesDirectory))
            {
                return;
            }
        }

        var zipFiles = Directory.GetFiles(quizzesDirectory, "*.zip");
        foreach (var zipFile in zipFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(zipFile);
            AvailableQuizzes.Add(new QuizFileInfo
            {
                Name = fileName,
                FilePath = zipFile
            });
        }
    }

    [RelayCommand]
    private async Task StartQuizAsync()
    {
        if (SelectedQuiz == null) return;

        try
        {
            var quiz = await QuizLoader.LoadQuizFromZipAsync(SelectedQuiz.FilePath);
            if (quiz != null)
            {
                CurrentView = new QuizViewModel(quiz);
            }
        }
        catch (Exception ex)
        {
            // In a real app, show an error dialog
            Console.WriteLine($"Error loading quiz: {ex.Message}");
        }
    }

    [RelayCommand]
    private void BackToMenu()
    {
        CurrentView = null;
        SelectedQuiz = null;
    }
}

public partial class QuizFileInfo : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _filePath = string.Empty;
}
