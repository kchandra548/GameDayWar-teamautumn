public class AccessAdminPanelClass
{
    private const string AdminUsername = "admin";

    public void AccessAdminPanel(string username)
    {
        if (username == AdminUsername) // Use constant for admin username
        {
            Console.WriteLine("Access to Admin Panel Granted!");
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }
}
