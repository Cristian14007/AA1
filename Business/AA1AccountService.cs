using AA1.Data;

namespace AA1.Business
{
    public class AA1AccountService : IAA1AccountService
    {
        private readonly IAA1AccountRepository _repository;

        public AA1AccountService(IAA1AccountRepository repository)
        {
            _repository = repository;
        }

        public void MakeDeposit(string accountNumber, decimal amount, string note)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }

            account.MakeDeposit(amount, DateTime.Now, note);
            _repository.UpdateAccount(account);
            _repository.SaveChanges();
        }

        public void MakeWithdrawal(string accountNumber, decimal amount, string note)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }

            account.MakeWithdrawal(amount, DateTime.Now, note);
            _repository.UpdateAccount(account);
            _repository.SaveChanges();
        }

        public string GetAccountHistory(string accountNumber)
        {
            var account = _repository.GetAccount(accountNumber);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found.");
            }

            return account.GetAccountHistory();
        }

        // Métodos para crear cuenta, buscar cuenta, etc.
    }
}
