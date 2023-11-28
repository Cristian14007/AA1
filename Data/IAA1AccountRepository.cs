using AA1.Models;

namespace AA1.Data
{
    public interface IAA1AccountRepository
    {
        void AddAccount(AA1Account account);
        AA1Account GetAccount(string accountNumber);
        void UpdateAccount(AA1Account account);
        void SaveChanges();


    }
}
