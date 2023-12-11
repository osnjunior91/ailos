
namespace Questao5.Infrastructure.Database.Idempotence
{
    public interface IIdempotenceRepository
    {
        Task CreateAsync(string input, string output);
    }
}
