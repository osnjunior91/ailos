namespace Questao5.Application.Queries.Responses
{
    public class BalanceQueryResponse
    {
        public BalanceQueryResponse(string accountNumber, string accountHolderName, DateTime responseDateTime, decimal currentBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            ResponseDateTime = responseDateTime;
            CurrentBalance = currentBalance;
        }

        public string AccountNumber { get; private set; }
        public string AccountHolderName { get; private set; }
        public DateTime ResponseDateTime { get; private set; }
        public decimal CurrentBalance { get; private set; }
    }
}
