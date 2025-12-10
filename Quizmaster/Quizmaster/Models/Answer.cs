namespace Quizmaster.Models;

/// <summary>
/// Represents a possible answer to a question
/// </summary>
public class Answer
{
    /// <summary>
    /// The answer text
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Optional HTML formatted version of the answer text
    /// </summary>
    public string? TextHtml { get; set; }

    /// <summary>
    /// Indicates whether this is the correct answer
    /// </summary>
    public bool IsCorrect { get; set; }
}
