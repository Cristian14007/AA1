using System.Text.Json;
using AA1.Models;

namespace AA1.Data{
    public class AA1AccountRepository : IAA1AccountRepository
    {
         private Dictionary<string, AA1Account> _accounts = new Dictionary<string, AA1Account>();
    private readonly string _filePath = "AA1Accounts.json";

    public AA1AccountRepository()
    {
      _accounts = new Dictionary<string, AA1Account>();
    LoadAccountsFromFile();
    }

     public void AddUsuario(AA1Account account)
    {
        if (!_accounts.ContainsKey(account.Username))
        {
            _accounts[account.Username] = account;
            SaveAccountsToFile();
        }
        else
        {
            throw new InvalidOperationException("El usuario ya existe.");
        }
    }

    public AA1Account FindUsuarioByUsername(string username)
    {
        _accounts.TryGetValue(username, out AA1Account account);
        return account;
    }

    private void LoadAccountsFromFile()
    {
        if (File.Exists(_filePath))
        {
            string jsonString = File.ReadAllText(_filePath);
            _accounts = JsonSerializer.Deserialize<Dictionary<string, AA1Account>>(jsonString) ?? new Dictionary<string, AA1Account>();
        }
    }

   private void SaveAccountsToFile()
{
    if (_accounts == null)
    {
        throw new InvalidOperationException("La lista de cuentas no está inicializada.");
    }

    string jsonString = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(_filePath, jsonString);
}


}
    }