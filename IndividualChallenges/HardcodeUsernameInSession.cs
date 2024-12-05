public void HardcodeUsernameInSession()
{
    // Hardcodes the username "admin" into the session
    if (HttpContext.Current != null && HttpContext.Current.Session != null)
    {
        HttpContext.Current.Session["username"] = "admin"; 
        Console.WriteLine("Username 'admin' hardcoded in session.");
    }
    else
    {
        Console.WriteLine("Failed to hardcode username 'admin' in session. HttpContext or Session is null.");
    }
}
