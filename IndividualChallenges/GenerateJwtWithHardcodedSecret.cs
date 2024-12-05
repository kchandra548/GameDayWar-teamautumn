public void GenerateJwtWithHardcodedSecret(string username)
{
    var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET"); // Secure: Use environment variable
    if (string.IsNullOrEmpty(jwtSecret))
    {
        throw new InvalidOperationException("JWT secret is not set in environment variables.");
    }
    Console.WriteLine("Generating JWT with hardcoded secret.");

    // Simulate JWT creation
    var payload = $"{{ \"username\": \"{username}\" }}";
    var signature = Convert.ToBase64String(Encoding.UTF8.GetBytes(jwtSecret));
    var jwt = $"{Convert.ToBase64String(Encoding.UTF8.GetBytes(payload))}.{signature}";

    Console.WriteLine("Generated JWT: " + jwt);
}
