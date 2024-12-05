public void DeleteDirectory(string folderName)
{
    try
    {
        // Validate and sanitize the input
        string safeFolderName = Path.GetFileName(folderName);
        string safePath = Path.Combine("C:\\Sensitive\\", safeFolderName);

        // Check if the directory exists
        if (Directory.Exists(safePath))
        {
            // Delete the directory
            Directory.Delete(safePath, true);
            Console.WriteLine($"Deleted directory: {safePath}");
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting directory: {ex.Message}");
    }
    
    // Deletes a directory based on unvalidated user input
    // Directory.Delete("C:\\Sensitive\\" + folderName, true);
    // Console.WriteLine($"Deleted directory: C:\\Sensitive\\{folderName}");
}
