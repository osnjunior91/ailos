using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(string accountId);
    }
}
