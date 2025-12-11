using System.Collections.Generic;

namespace Quizmaster.Models;

/// <summary>
/// Represents a single multiple-choice question
/// </summary>
public class Question
{
    /// <summary>
    /// The question text
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Optional HTML formatted version of the question text
    /// </summary>
    public string? TextHtml { get; set; }

    /// <summary>
    /// Optional image filename (relative to the zip file)
    /// </summary>
    public string? ImageFileName { get; set; }

    /// <summary>
    /// List of possible answers
    /// </summary>
    public List<Answer> Answers { get; set; } = new();

    /// <summary>
    /// Optional explanation shown after answering
    /// </summary>
    public string? Explanation { get; set; }

    /// <summary>
    /// Optional HTML formatted explanation
    /// </summary>
    public string? ExplanationHtml { get; set; }
}
