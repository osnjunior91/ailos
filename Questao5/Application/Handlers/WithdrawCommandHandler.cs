using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Infrastructure.Database.QueryStore;
using static Questao5.Domain.Enumerators.Erros;

namespace Questao5.Application.Handlers
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommandRequest, WithdrawCommandResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public WithdrawCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<WithdrawCommandResponse> Handle(WithdrawCommandRequest request, CancellationToken cancellationToken)
        {
            var accountData = await _accountRepository.GetAccountByIdAsync(request.AccountId);

            if (accountData == null)
                throw new BusinessException(ErrorType.INVALID_ACCOUNT);
            if (!accountData.IsActive)
                throw new BusinessException(ErrorType.INACTIVE_ACCOUNT);
            
            
            throw new NotImplementedException();
        }
    }
}
