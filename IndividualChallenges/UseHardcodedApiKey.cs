public void UseHardcodedApiKey()
{
    string apiKey = Environment.GetEnvironmentVariable("API_KEY"); // Secure: Retrieve API key from environment variable
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("API key is not set in environment variables.");
    }
    Console.WriteLine("Using API key: " + apiKey);

    // Simulate API usage
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    var response = client.GetAsync("https://api.example.com/data").Result;
    Console.WriteLine("Response: " + response.StatusCode);
}
