using MediatR;
using NSubstitute.ReturnsExtensions;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Infrastructure.Database.CommandStore;
using Questao5.Infrastructure.Database.QueryStore;
using static Questao5.Domain.Enumerators.Erros;

namespace Questao5.Application.Handlers
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommandRequest, WithdrawCommandResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IWithdrawRepository _withdrawRepository;

        public WithdrawCommandHandler(IAccountRepository accountRepository, IWithdrawRepository withdrawRepository)
        {
            _accountRepository = accountRepository;
            _withdrawRepository = withdrawRepository;
        }

        public async Task<WithdrawCommandResponse> Handle(WithdrawCommandRequest request, CancellationToken cancellationToken)
        {
            var accountData = await _accountRepository.GetAccountByIdAsync(request.AccountId);

            if (accountData == null)
                throw new BusinessException(ErrorType.INVALID_ACCOUNT);
            if (!accountData.IsActive)
                throw new BusinessException(ErrorType.INACTIVE_ACCOUNT);

            var idWithdraw = await _withdrawRepository.CreateWithdrawAsync(request);
            return new WithdrawCommandResponse(idWithdraw);
        }
    }
}
