using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Handlers
{
    public class AccountBalanceQueryHandler : IRequestHandler<BalanceQueryRequest, BalanceQueryResponse>
    {
        public Task<BalanceQueryResponse> Handle(BalanceQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
