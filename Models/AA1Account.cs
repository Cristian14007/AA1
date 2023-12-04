namespace AA1.Models;

using System.Text;
using System.Text.Json;
public class AA1Account
{
    private static Random random = new Random();

    public string? ID { get; set; }


    public string Username { get; set; }


    public string Email { get; set; }


    public string Password { get; set; }


    public DateTime CreatedAt { get; set; }


    public bool IsAdmin { get; set; }


    public AA1Account() { }


    public AA1Account(string username, string email, string password)
    {
        ID = GenerateRandomAccountNumber();
        Username = username;
        Email = email;
        Password = password;

    }
    private string GenerateRandomAccountNumber()
    {

        return random.Next(10000000, 100000000).ToString();
    }

    public static bool UserExists(string username)
    {
        var users = GetUserAccounts();
        return users.Any(u => u.Value.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }


    public static Dictionary<string, AA1Account> GetUserAccounts()
    {
        string jsonString = File.ReadAllText("AA1Account.json");
        return JsonSerializer.Deserialize<Dictionary<string, AA1Account>>(jsonString) ?? new Dictionary<string, AA1Account>();
    }

}
