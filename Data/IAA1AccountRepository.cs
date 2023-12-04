using AA1.Models;

namespace AA1.Data
{
    public interface IAA1AccountRepository
    {
        void AddUsuario(AA1Account account);
        AA1Account FindUsuarioByUsername(string username);
        //AA1Account FindUsuarioById(int id);
        void LoadAccountsFromFile();
        void SaveAccountsToFile();



    }
}
