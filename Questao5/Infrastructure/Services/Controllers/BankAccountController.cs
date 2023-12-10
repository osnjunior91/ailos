using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        public IMediator _mediator;

        public BankAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "AccountBalance/{accountId}")]
        public async Task<ActionResult> GetAsync(string accountId)
        {
            var result = await _mediator.Send(new BalanceQueryRequest(accountId));
            return Ok(result);
        }
    }
}
