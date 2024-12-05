using System.Web;
using System.Text.RegularExpressions;

public void AddUserInputToCookie(string userInput)
{
    // Validate and sanitize user input
    if (string.IsNullOrEmpty(userInput) || !Regex.IsMatch(userInput, @"^[a-zA-Z0-9]+$"))
    {
        throw new ArgumentException("Invalid user input");
    }

    Response.Cookies.Add(new HttpCookie("SessionID", userInput)); 
    Console.WriteLine("Cookie added with user input: " + userInput);
}