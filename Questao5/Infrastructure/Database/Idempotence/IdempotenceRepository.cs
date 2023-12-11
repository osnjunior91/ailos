using Dapper;

namespace Questao5.Infrastructure.Database.Idempotence
{
    public class IdempotenceRepository : IIdempotenceRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public IdempotenceRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task CreateAsync(string input, string output)
        {
            using (var connection = _connectionFactory.SqliteCreateConnection())
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO movimento (chave_idempotencia, requisicao, resultado)
                VALUES (@id, @input, @output)
            ";

                var parameters = new
                {
                    id = Guid.NewGuid().ToString(),
                    input,
                    output
                };

                await connection.ExecuteAsync(insertQuery, parameters);
            }
        }
    }
}
