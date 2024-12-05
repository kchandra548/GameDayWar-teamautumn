public void DeleteFile(string userInput)
{
    // Deletes a file based on unvalidated user input
    if (string.IsNullOrWhiteSpace(userInput) || !File.Exists(userInput))
    {
        Console.WriteLine("Invalid file path.");
        return;
    }

    File.Delete(userInput); 
    Console.WriteLine($"Deleted file: {userInput}");
}
