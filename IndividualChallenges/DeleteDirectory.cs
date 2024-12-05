public void DeleteDirectory(string folderName)
{
    // Validate the folder name to prevent directory traversal attacks
    if (string.IsNullOrWhiteSpace(folderName) || folderName.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
    {
        throw new ArgumentException("Invalid folder name", nameof(folderName));
    }

    string fullPath = Path.Combine("C:\\Sensitive", folderName);
    if (!fullPath.StartsWith("C:\\Sensitive\\"))
    {
        throw new UnauthorizedAccessException("Access to the path is denied.");
    }

    // Deletes a directory based on validated user input
    Directory.Delete(fullPath, true);
    Console.WriteLine($"Deleted directory: {fullPath}");
}
