namespace AA1.Business
{
    public interface IAA1AccountService
    {
        void MakeDeposit(string accountNumber, decimal amount, string note);
        void MakeWithdrawal(string accountNumber, decimal amount, string note);
        string GetAccountHistory(string accountNumber);

    }
}
