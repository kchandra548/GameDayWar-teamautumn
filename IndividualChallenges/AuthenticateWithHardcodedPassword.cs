public void AuthenticateWithPassword(string password)
{
    Console.WriteLine("Authenticating with provided password.");

    // Simulate authentication
    if (password == "P@ssword!")
    {
        Console.WriteLine("Authentication successful.");
    }
    else
    {
        Console.WriteLine("Authentication failed.");
    }
}
