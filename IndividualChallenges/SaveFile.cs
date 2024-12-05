using System;
using System.IO;

public void SaveFile(string userInput, byte[] fileContent)
{
    // Validate and sanitize the user input
    if (string.IsNullOrWhiteSpace(userInput) || userInput.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
    {
        throw new ArgumentException("Invalid file name.");
    }

    // Use a secure directory for file uploads
    string secureDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
    if (!Directory.Exists(secureDirectory))
    {
        Directory.CreateDirectory(secureDirectory);
    }

    // Combine the secure directory with the sanitized file name
    string filePath = Path.Combine(secureDirectory, userInput);

    // Ensure the file path is within the secure directory
    if (!filePath.StartsWith(secureDirectory))
    {
        throw new UnauthorizedAccessException("Invalid file path.");
    }

    // Save the file content to the specified path
    File.WriteAllBytes(filePath, fileContent);

    // Log a generic message without exposing the file path
    Console.WriteLine("File saved successfully.");
}
