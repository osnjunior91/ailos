using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public IMediator _mediator;

        public BankAccountController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
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
