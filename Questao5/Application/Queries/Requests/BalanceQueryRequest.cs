using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class BalanceQueryRequest :  IRequest<BalanceQueryResponse>
    {
        public BalanceQueryRequest(string accountId)
        {
            AccountId = accountId;
        }

        public string AccountId {get; private set;}
    }
}
