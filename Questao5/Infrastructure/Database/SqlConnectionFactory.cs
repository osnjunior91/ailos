using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseConfig _databaseConfig;

        public SqlConnectionFactory(IConfiguration configuration, DatabaseConfig databaseConfig)
        {
            _configuration = configuration;
            _databaseConfig = databaseConfig;

        }

        public SqliteConnection SqliteCreateConnection()
        {
            return new SqliteConnection(_databaseConfig.Name);
        }
    }
}
