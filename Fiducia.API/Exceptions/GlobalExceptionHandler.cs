using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Fiducia.API.Exceptions
{
    internal sealed class GlobalExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<GlobalExceptionHandler> logger,
        IHostEnvironment hostEnvironment) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(exception, "Unhandled exception ocurred.");

            httpContext.Response.StatusCode = exception switch
            {
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            { 
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails 
                {
                    Type = exception.GetType().Name,
                    Title = "An error ocurred",
                    Detail = hostEnvironment.IsDevelopment() ? exception.Message
                    : "An unexpected error ocurred."
                }
            });

            
        }

    }

}
