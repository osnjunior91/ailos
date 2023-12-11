using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public AccountRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Account> GetAccountByIdAsync(string accountId)
        {
            using (var connection = _connectionFactory.SqliteCreateConnection())
            {
                connection.Open();

                var reponse = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SELECT * FROM contacorrente WHERE idcontacorrente = @AccountId",
                    new { AccountId = accountId });

                if (reponse != null)
                {
                    Account account = new Account(reponse);
                    account.SetOperations(GetMovementsForAccount(accountId, connection).ToList());
                    return account;
                }

                return null;
            }
        }

        private IEnumerable<Operation> GetMovementsForAccount(string accountId, SqliteConnection connection)
        {
            var response = connection.Query<dynamic>(
                "SELECT * FROM movimento WHERE idcontacorrente = @AccountId",
                new { AccountId = accountId });
            return response.Select(x => new Operation(x));
        }
    }
}
