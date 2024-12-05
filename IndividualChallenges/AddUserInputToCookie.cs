public void AddUserInputToCookie(string userInput)
{
    // Validate and sanitize user input before adding to cookies
    if (string.IsNullOrEmpty(userInput) || !IsValidInput(userInput))
    {
        throw new ArgumentException("Invalid user input");
    }
    // User input added directly to cookies without validation
    Response.Cookies.Add(new HttpCookie("SessionID", userInput)); 
    Console.WriteLine("Cookie added with user input: " + userInput);
}


private bool IsValidInput(string input)
{
    // Add your input validation logic here
    return input.All(char.IsLetterOrDigit);
}
