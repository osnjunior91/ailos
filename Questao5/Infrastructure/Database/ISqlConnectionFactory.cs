using Microsoft.Data.Sqlite;

namespace Questao5.Infrastructure.Database
{
    public interface ISqlConnectionFactory
    {
        SqliteConnection SqliteCreateConnection();
    }
}
