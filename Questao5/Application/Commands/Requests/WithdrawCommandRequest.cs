using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;
using static Questao5.Domain.Enumerators.Operation;

namespace Questao5.Application.Commands.Requests
{
    public class WithdrawCommandRequest : IRequest<WithdrawCommandResponse>
    {
        public WithdrawCommandRequest(string accountId, decimal value, string type)
        {
            if (value <= 0)
                throw new BusinessException(Erros.ErrorType.INVALID_VALUE);

            type.ToFinancialOperationType();

            AccountId = accountId;
            Value = value;
            Type = type;
        }

        public string AccountId {  get; private set; }
        public decimal Value { get; private set; }
        public string Type { get; private set; }
    }
}
