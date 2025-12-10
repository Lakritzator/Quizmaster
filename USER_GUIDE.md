# Quizmaster User Guide

## Getting Started

### Running the Application

#### Windows, Linux, or macOS
```bash
cd Quizmaster
dotnet run --project Quizmaster.Desktop/Quizmaster.Desktop.csproj
```

Or build and run the executable:
```bash
cd Quizmaster
dotnet build Quizmaster.Desktop/Quizmaster.Desktop.csproj
cd Quizmaster.Desktop/bin/Debug/net9.0/
./Quizmaster.Desktop  # Linux/macOS
# or
Quizmaster.Desktop.exe  # Windows
```

## Using the Application

### Main Menu

When you start the application, you'll see the quiz selection screen with:
- A list of available quizzes
- A "Start Quiz" button (enabled when a quiz is selected)

**To begin:**
1. Click on a quiz from the list
2. Click the "Start Quiz" button

### Taking a Quiz

The quiz screen shows:
- **Header**: Quiz title, current question number, and total questions
- **Question**: The question text
- **Answers**: Multiple choice buttons
- **Navigation**: Previous/Next buttons

**How to answer:**
1. Read the question carefully
2. Click on your answer choice
3. An explanation will appear (if available)
4. Click "Next" to continue to the next question
5. Use "Previous" to review earlier questions (you can't change answers)

### Completing a Quiz

After answering all questions:
- Your score is displayed as a percentage
- You can choose to:
  - **Restart Quiz**: Take the quiz again with questions in the same order
  - **Back to Menu**: Return to quiz selection

### Navigation

- **Back to Menu** button in the header: Return to quiz selection at any time
- **Previous/Next** buttons: Navigate between questions
- Quiz progress is shown in the header

## Quiz Content

### Included Quizzes

1. **ArchiMate Foundation** (10 questions)
   - Covers fundamental ArchiMate 3.2 concepts
   - Topics: layers, elements, relationships, basic modeling

2. **ArchiMate Practitioner** (12 questions)
   - Advanced ArchiMate knowledge
   - Topics: detailed relationships, viewpoints, motivation extension, implementation & migration

## Adding Custom Quizzes

See [Quizzes/README.md](Quizzes/README.md) for details on creating your own quiz files.

### Quick Steps:
1. Create a `quiz.json` file following the schema
2. Add any images (optional)
3. Create a ZIP file with all content
4. Place the ZIP file in the `Quizzes` directory
5. Restart the application

## Tips

- Take your time reading each question
- Read all answer options before selecting
- Review explanations to learn from incorrect answers
- Retake quizzes to reinforce learning
- Track your score improvement over time

## Troubleshooting

### No quizzes appear
- Ensure ZIP files are in the `Quizzes` directory
- Check that ZIP files contain a valid `quiz.json` file
- Verify the JSON structure matches the schema

### Application won't start
- Ensure .NET 9.0 SDK is installed
- Try rebuilding: `dotnet build Quizmaster.Desktop/Quizmaster.Desktop.csproj`

### Quiz loads but shows errors
- Verify the quiz.json structure
- Ensure all required fields are present
- Check that image references match files in the ZIP

## Keyboard Shortcuts

Currently, the application is primarily mouse/touch-driven. Keyboard navigation may be added in future versions.

## Future Enhancements

Potential future features include:
- Image display in questions
- Progress saving
- Randomized question order
- Timed quizzes
- Quiz statistics and history
- Multi-language support
