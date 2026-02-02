using Microsoft.AspNetCore.Diagnostics;
using Fiducia.Domain.Exceptions;

namespace Fiducia.API.Exceptions
{
    internal sealed class TypeOfAmortizationExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            if (exception is not TypeOfAmortizationException typeOfAmortizationException)
            {
                return false;
            }

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var context = new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new()
                {
                    Detail = exception.Message,
                    Status = StatusCodes.Status400BadRequest
                }
            };

            return await problemDetailsService.TryWriteAsync(context);
        }
    }
}
