using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quizmaster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Quizmaster.ViewModels;

/// <summary>
/// ViewModel for displaying and managing a quiz session
/// </summary>
public partial class QuizViewModel : ViewModelBase
{
    private readonly Quiz _quiz;
    private readonly List<int> _userAnswers;
    private int _currentQuestionIndex;
    private readonly Action? _onBackToMenu;

    [ObservableProperty]
    private string _quizTitle = string.Empty;

    [ObservableProperty]
    private string _currentQuestionText = string.Empty;

    [ObservableProperty]
    private string? _currentQuestionImageFileName;

    [ObservableProperty]
    private ObservableCollection<AnswerViewModel> _currentAnswers = new();

    [ObservableProperty]
    private int _questionNumber;

    [ObservableProperty]
    private int _totalQuestions;

    [ObservableProperty]
    private bool _isQuizComplete;

    [ObservableProperty]
    private int _score;

    [ObservableProperty]
    private string? _currentExplanation;

    [ObservableProperty]
    private bool _hasAnswered;

    // New properties for tracking correct/incorrect answers and feedback
    [ObservableProperty]
    private int _correctAnswersCount;

    [ObservableProperty]
    private int _incorrectAnswersCount;

    [ObservableProperty]
    private string? _lastAnswerFeedback;

    [ObservableProperty]
    private bool _lastAnswerWasCorrect;

    public QuizViewModel(Quiz quiz, Action? onBackToMenu = null)
    {
        _quiz = quiz;
        _userAnswers = Enumerable.Repeat(-1, quiz.Questions.Count).ToList();
        _currentQuestionIndex = 0;
        _onBackToMenu = onBackToMenu;
        QuizTitle = quiz.Title;
        TotalQuestions = quiz.Questions.Count;
        CorrectAnswersCount = 0;
        IncorrectAnswersCount = 0;
        LoadCurrentQuestion();
    }

    private void LoadCurrentQuestion()
    {
        if (_currentQuestionIndex >= _quiz.Questions.Count)
        {
            return;
        }

        var question = _quiz.Questions[_currentQuestionIndex];
        CurrentQuestionText = question.TextHtml ?? question.Text;
        CurrentQuestionImageFileName = question.ImageFileName;
        QuestionNumber = _currentQuestionIndex + 1;
        HasAnswered = false;
        CurrentExplanation = null;
        LastAnswerFeedback = null;
        LastAnswerWasCorrect = false;

        CurrentAnswers = new ObservableCollection<AnswerViewModel>(
            question.Answers.Select((answer, index) => new AnswerViewModel
            {
                Text = answer.TextHtml ?? answer.Text,
                Index = index,
                IsCorrect = answer.IsCorrect
            })
        );
    }

    [RelayCommand]
    private void SelectAnswer(int answerIndex)
    {
        if (HasAnswered) return;

        _userAnswers[_currentQuestionIndex] = answerIndex;
        HasAnswered = true;

        var question = _quiz.Questions[_currentQuestionIndex];
        var selectedAnswer = CurrentAnswers[answerIndex];
        selectedAnswer.IsSelected = true;

        foreach (var answer in CurrentAnswers)
        {
            answer.ShowCorrectness = true;
            answer.ShowResult = true;
        }

        // Show explanation if available
        CurrentExplanation = question.ExplanationHtml ?? question.Explanation;

        // Track correct/incorrect answers and provide feedback
        if (selectedAnswer.IsCorrect)
        {
            CorrectAnswersCount++;
            LastAnswerFeedback = "Correct!";
            LastAnswerWasCorrect = true;
        }
        else
        {
            IncorrectAnswersCount++;
            LastAnswerFeedback = "Incorrect!";
            LastAnswerWasCorrect = false;
        }
    }

    [RelayCommand]
    private void NextQuestion()
    {
        if (_currentQuestionIndex < _quiz.Questions.Count - 1)
        {
            _currentQuestionIndex++;
            LoadCurrentQuestion();
        }
        else
        {
            CompleteQuiz();
        }
    }

    [RelayCommand]
    private void PreviousQuestion()
    {
        if (_currentQuestionIndex > 0)
        {
            _currentQuestionIndex--;
            LoadCurrentQuestion();
        }
    }

    private void CompleteQuiz()
    {
        IsQuizComplete = true;

        // Calculate score
        int correctAnswers = 0;
        for (int i = 0; i < _quiz.Questions.Count; i++)
        {
            if (_userAnswers[i] >= 0)
            {
                var question = _quiz.Questions[i];
                if (question.Answers[_userAnswers[i]].IsCorrect)
                {
                    correctAnswers++;
                }
            }
        }

        Score = (int)((double)correctAnswers / _quiz.Questions.Count * 100);
    }

    [RelayCommand]
    private void RestartQuiz()
    {
        _currentQuestionIndex = 0;
        _userAnswers.Clear();
        _userAnswers.AddRange(Enumerable.Repeat(-1, _quiz.Questions.Count));
        IsQuizComplete = false;
        Score = 0;
        CorrectAnswersCount = 0;
        IncorrectAnswersCount = 0;
        LastAnswerFeedback = null;
        LastAnswerWasCorrect = false;
        LoadCurrentQuestion();
    }

    [RelayCommand]
    private void BackToMenu()
    {
        _onBackToMenu?.Invoke();
    }
}

/// <summary>
/// ViewModel for a single answer option
/// </summary>
public partial class AnswerViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _showResult;

    [ObservableProperty]
    private string _text = string.Empty;

    [ObservableProperty]
    private int _index;

    [ObservableProperty]
    private bool _isCorrect;

    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    private bool _showCorrectness;
}
