using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public interface IWithdrawRepository
    {
        Task<string> CreateWithdrawAsync(WithdrawCommandRequest request);
    }
}
