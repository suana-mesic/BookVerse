using Market.Application.Common.Exceptions;
using System.Text.Json;

namespace Market.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // pusti request dalje kroz pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.ContentType = "application/json";

                int statusCode = 500;
                string message = "Internal server error";

                if (ex is MarketNotFoundException)
                {
                    statusCode = 404;
                    message = ex.Message;
                }
                else if (ex is MarketConflictException)
                {
                    statusCode = 400;
                    message = ex.Message;
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { message }));
            }
        }
    }
}
