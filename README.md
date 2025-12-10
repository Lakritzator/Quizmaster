# Quizmaster

A cross-platform quiz application built with Avalonia UI for .NET, designed to help prepare for ArchiMate certifications.

## Features

- 🎯 Multiple choice quiz system
- 📦 Quiz files stored as ZIP archives with JSON structure
- 🖼️ Support for images in questions
- 📝 HTML formatting support for questions, answers, and explanations
- 🎨 Modern Fluent UI design
- 🌐 Cross-platform support (Windows, Linux, macOS, iOS, Android, Browser)
- 📊 Score tracking and results display
- ✅ Immediate feedback with explanations

## Included Quizzes

- **ArchiMate Foundation** - 10 questions covering fundamental ArchiMate concepts
- **ArchiMate Practitioner** - 12 questions for advanced ArchiMate knowledge

## Building and Running

### Prerequisites

- .NET 9.0 SDK or later
- For iOS/Android: Additional workloads required (`dotnet workload restore`)

### Desktop (Windows, Linux, macOS)

```bash
cd Quizmaster
dotnet build Quizmaster.Desktop/Quizmaster.Desktop.csproj
dotnet run --project Quizmaster.Desktop/Quizmaster.Desktop.csproj
```

### Browser (WebAssembly)

```bash
cd Quizmaster
dotnet workload restore
dotnet run --project Quizmaster.Browser/Quizmaster.Browser.csproj
```

## Adding New Quizzes

See [Quizzes/README.md](Quizzes/README.md) for details on creating and adding new quiz files.

## Quiz File Format

Quiz files are ZIP archives containing:
- `quiz.json` - Quiz definition with questions and answers
- Optional image files referenced in questions

### Example quiz.json structure:

```json
{
  "title": "My Quiz",
  "text": "Quiz description",
  "questions": [
    {
      "text": "Question text",
      "imageFileName": "optional-image.png",
      "answers": [
        {
          "text": "Answer 1",
          "isCorrect": false
        },
        {
          "text": "Correct answer",
          "isCorrect": true
        }
      ],
      "explanation": "Why this is the correct answer"
    }
  ]
}
```

## Technology Stack

- **UI Framework**: Avalonia UI 11.3
- **MVVM**: CommunityToolkit.Mvvm
- **Target Framework**: .NET 9.0
- **Architecture**: MVVM pattern with ViewModels and Views

## License

MIT License - See [LICENSE](LICENSE) file for details.
