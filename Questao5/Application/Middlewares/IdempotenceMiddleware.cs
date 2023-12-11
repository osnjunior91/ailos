using Newtonsoft.Json;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Idempotence;
using System.Text;

namespace Questao5.Application.Middlewares
{
    public class IdempotenceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IIdempotenceRepository _idempotenceRepository;

        public IdempotenceMiddleware(RequestDelegate next, IIdempotenceRepository idempotenceRepository)
        {
            _next = next;
            _idempotenceRepository = idempotenceRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            string input;
            string output;
            input = await FormatRequest(context.Request);
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                output = await FormatResponse(context.Response);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            try
            {
                _idempotenceRepository.CreateAsync(input, output);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            return $"{request.Scheme} {request.Host}{request.Path}{request.QueryString} {Environment.NewLine} {request.Headers} {Environment.NewLine}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}: {text}";
        }
    }
}
