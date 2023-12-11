using Dapper;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Enumerators;


namespace Questao5.Infrastructure.Database.CommandStore
{
    public class WithdrawRepository : IWithdrawRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public WithdrawRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<string> CreateWithdrawAsync(WithdrawCommandRequest request)
        {
            string idMovimento = Guid.NewGuid().ToString();
            string dataMovimento = DateTime.Now.ToString("dd/MM/yyyy");

            using (var connection = _connectionFactory.SqliteCreateConnection())
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)
                VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)
            ";

                var parameters = new
                {
                    IdMovimento = idMovimento,
                    IdContaCorrente = request.AccountId,
                    DataMovimento = dataMovimento,
                    TipoMovimento = request.Type.ToValue(),
                    Valor = request.Value
                };

                await connection.ExecuteAsync(insertQuery, parameters);
            }

            return idMovimento;
        }
    }
}
