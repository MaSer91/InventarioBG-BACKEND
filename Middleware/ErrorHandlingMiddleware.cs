using InventarioBackend.Models;

namespace InventarioBackend.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal: {ex}");
                httpContext.Response.StatusCode = 500;
                //await httpContext.Response.WriteAsJsonAsync(new ErrorResponse("Error inesperado", ex.Message));
            }
        }
    }
}
