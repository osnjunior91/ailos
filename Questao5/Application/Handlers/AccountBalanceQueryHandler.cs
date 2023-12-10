﻿using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Database.QueryStore;
using static Questao5.Domain.Enumerators.Erros;

namespace Questao5.Application.Handlers
{
    public class AccountBalanceQueryHandler : IRequestHandler<BalanceQueryRequest, BalanceQueryResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountBalanceQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<BalanceQueryResponse> Handle(BalanceQueryRequest request, CancellationToken cancellationToken)
        {
            var accountData = await _accountRepository.GetAccountByIdAsync(request.AccountId);

            if (accountData == null)
                throw new BusinessException(ErrorType.INVALID_ACCOUNT);
            if(!accountData.IsActive)
                throw new BusinessException(ErrorType.INACTIVE_ACCOUNT);

            return new BalanceQueryResponse(accountData.Number, accountData.Name, DateTime.Now, 0);
        }
    }
}
