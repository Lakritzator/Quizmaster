# Quizmaster Quiz Files

This directory contains quiz files in ZIP format. Each quiz file should contain a `quiz.json` file with the quiz structure and optionally image files referenced in the questions.

## Quiz File Structure

Each quiz ZIP file should contain:
- `quiz.json` - The quiz definition (required)
- Image files (optional) - Referenced by questions

## quiz.json Format

```json
{
  "title": "Quiz Title",
  "text": "Quiz description or introduction text",
  "textHtml": "Optional HTML formatted description",
  "metadata": {
    "version": "1.0",
    "author": "Author Name",
    "certification": "Optional certification name"
  },
  "questions": [
    {
      "text": "Question text",
      "textHtml": "Optional HTML formatted question",
      "imageFileName": "optional-image.png",
      "answers": [
        {
          "text": "Answer option 1",
          "textHtml": "Optional HTML formatted answer",
          "isCorrect": false
        },
        {
          "text": "Correct answer",
          "isCorrect": true
        }
      ],
      "explanation": "Optional explanation shown after answering",
      "explanationHtml": "Optional HTML formatted explanation"
    }
  ]
}
```

## Creating a New Quiz

1. Create a `quiz.json` file following the format above
2. Add any images referenced in your questions
3. Create a ZIP file containing all files (images should be in the root of the ZIP)
4. Name the ZIP file descriptively (e.g., `My-Quiz-Name.zip`)
5. Place the ZIP file in this directory

## Sample Quizzes

- **ArchiMate-Foundation.zip** - Foundation level ArchiMate certification quiz (10 questions)
- **ArchiMate-Practitioner.zip** - Practitioner level ArchiMate certification quiz (12 questions)

## HTML Formatting

HTML formatting is supported in the following fields:
- `textHtml` (quiz description)
- `textHtml` (question text)
- `textHtml` (answer text)
- `explanationHtml` (explanation text)

Basic HTML tags are supported. Complex styling may not render correctly.
