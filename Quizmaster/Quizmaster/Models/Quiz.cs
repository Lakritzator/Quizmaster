using System.Collections.Generic;

namespace Quizmaster.Models;

/// <summary>
/// Represents a complete quiz with metadata and questions
/// </summary>
public class Quiz
{
    /// <summary>
    /// The title of the quiz
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// A description or introduction text for the quiz
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Optional HTML formatted version of the text
    /// </summary>
    public string? TextHtml { get; set; }

    /// <summary>
    /// List of questions in this quiz
    /// </summary>
    public List<Question> Questions { get; set; } = new();

    /// <summary>
    /// Optional metadata like version, author, etc.
    /// </summary>
    public Dictionary<string, string>? Metadata { get; set; }
}
