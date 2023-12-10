using MediatR;
using Questao5.Application.Commands.Responses;
using static Questao5.Domain.Enumerators.Operation;

namespace Questao5.Application.Commands.Requests
{
    public class WithdrawCommandRequest : IRequest<WithdrawCommandResponse>
    {
        public WithdrawCommandRequest(string accountId, decimal value, FinancialOperationType type)
        {
            AccountId = accountId;
            Value = value;
            Type = type;
        }

        public string AccountId {  get; set; }
        public decimal Value { get; set; }
        public FinancialOperationType Type { get; set; }
    }
}
