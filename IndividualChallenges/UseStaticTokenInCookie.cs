using System;
using System.Web;
using System.Security.Cryptography;

public void UseDynamicTokenInCookie()
{
    // Generate a unique, secure token
    string token = GenerateSecureToken();

    // Create a cookie with the secure token
    HttpCookie authCookie = new HttpCookie("auth", token)
    {
        HttpOnly = true, // Prevents client-side script access
        Secure = true,   // Ensures the cookie is sent over HTTPS
        SameSite = SameSiteMode.Strict // Prevents CSRF attacks
    };

    // Add the cookie to the response
    HttpContext.Current.Response.Cookies.Add(authCookie);
    Console.WriteLine("Secure authentication token added to cookies.");
}

private string GenerateSecureToken()
{
    using (var rng = new RNGCryptoServiceProvider())
    {
        byte[] tokenData = new byte[32];
        rng.GetBytes(tokenData);
        return Convert.ToBase64String(tokenData);
    }
}
