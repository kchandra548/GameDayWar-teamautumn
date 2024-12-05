using System;
using System.IO;

public void WriteExceptionToFile(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception caughtEx)
    {
        // Use a secure directory for logging
        string secureDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        if (!Directory.Exists(secureDirectory))
        {
            Directory.CreateDirectory(secureDirectory);
        }

        // Combine the secure directory with the log file name
        string logFilePath = Path.Combine(secureDirectory, "error.log");

        // Ensure the file path is within the secure directory
        if (!logFilePath.StartsWith(secureDirectory))
        {
            throw new UnauthorizedAccessException("Invalid file path.");
        }

        // Write a generic error message to the log file
        File.WriteAllText(logFilePath, "An error occurred. Please check the application logs for more details.");

        // Optionally, log detailed exception information securely (e.g., using a logging framework)
        // LogException(caughtEx); // Implement a secure logging mechanism
    }
}

private void DoSomethingRisky()
{
    // Implementation of the risky operation
}
