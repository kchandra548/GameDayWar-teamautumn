public void DeleteFile(string userInput)
{
    try
    {
        // Validate and sanitize the input
        string safePath = Path.GetFullPath(userInput);
        if (!safePath.StartsWith("/safe/directory/"))
        {
            throw new UnauthorizedAccessException("Unauthorized file path.");
        }

        // Check if the file exists
        if (File.Exists(safePath))
        {
            // Delete the file
            File.Delete(safePath);
            Console.WriteLine($"Deleted file: {safePath}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting file: {ex.Message}");
    }
    // Deletes a file based on unvalidated user input
    // File.Delete(userInput); 
    // Console.WriteLine($"Deleted file: {userInput}");
}
