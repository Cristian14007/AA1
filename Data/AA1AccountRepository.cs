using System.Text.Json;
using AA1.Models;

namespace AA1.Data
{
    public class AA1AccountRepository : IAA1AccountRepository
    {
        private Dictionary<string, AA1Account> _accounts = new Dictionary<string, AA1Account>();
        private readonly string _filePath = "AA1Accounts.json";

        public AA1AccountRepository()
        {
            LoadAccounts();
        }
        public void AddAccount(AA1Account account)
        {
            _accounts[account.Number] = account;
        }

        public AA1Account GetAccount(string accountNumber)
        {
            return _accounts.TryGetValue(accountNumber, out var account) ? account : null;
        }

        public void UpdateAccount(AA1Account account)
        {
            _accounts[account.Number] = account;
        }

        public void SaveChanges()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_accounts.Values, options);
            File.WriteAllText(_filePath, jsonString);
        }

        private void LoadAccounts()
        {
            AA1Account AA1Account = new AA1Account("Alex",100);
            //_accounts.Add("123456",AA1Account);
            _accounts.Add(AA1Account.Number, AA1Account);

            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                var accounts = JsonSerializer.Deserialize<IEnumerable<AA1Account>>(jsonString);
                _accounts = accounts.ToDictionary(acc => acc.Number);
            }
           
        }
    }
}
