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
                    return new Account(reponse);
                    //account.SetOperations(GetMovementsForAccount(accountId, connection).ToList());
                }

                return null;
            }
        }

        private IEnumerable<Operation> GetMovementsForAccount(string accountId, SqliteConnection connection)
        {
            return connection.Query<Operation>(
                "SELECT * FROM movimento WHERE idcontacorrente = @AccountId",
                new { AccountId = accountId });
        }
    }
}
