using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading.Tasks;
using Quizmaster.Models;

namespace Quizmaster.Services;

/// <summary>
/// Service for loading quiz data from ZIP files
/// </summary>
public class QuizLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    /// <summary>
    /// Loads a quiz from a ZIP file
    /// </summary>
    /// <param name="zipFilePath">Path to the ZIP file containing the quiz</param>
    /// <returns>The loaded quiz, or null if loading failed</returns>
    public static async Task<Quiz?> LoadQuizFromZipAsync(string zipFilePath)
    {
        if (!File.Exists(zipFilePath))
        {
            throw new FileNotFoundException($"Quiz file not found: {zipFilePath}");
        }

        try
        {
            using var archive = ZipFile.OpenRead(zipFilePath);
            
            // Look for quiz.json in the root of the ZIP
            var quizEntry = archive.GetEntry("quiz.json");
            if (quizEntry == null)
            {
                throw new InvalidDataException("quiz.json not found in ZIP file");
            }

            using var stream = quizEntry.Open();
            var quiz = await JsonSerializer.DeserializeAsync<Quiz>(stream, JsonOptions);
            
            return quiz;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to load quiz from {zipFilePath}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Extracts an image from a quiz ZIP file
    /// </summary>
    /// <param name="zipFilePath">Path to the ZIP file</param>
    /// <param name="imageFileName">Name of the image file within the ZIP</param>
    /// <returns>Stream containing the image data</returns>
    public static Stream? GetImageFromZip(string zipFilePath, string imageFileName)
    {
        if (!File.Exists(zipFilePath))
        {
            return null;
        }

        try
        {
            using var archive = ZipFile.OpenRead(zipFilePath);
            var imageEntry = archive.GetEntry(imageFileName);
            
            if (imageEntry == null)
            {
                return null;
            }

            var memoryStream = new MemoryStream();
            using (var entryStream = imageEntry.Open())
            {
                entryStream.CopyTo(memoryStream);
            }
            
            memoryStream.Position = 0;
            return memoryStream;
        }
        catch
        {
            return null;
        }
    }
}
