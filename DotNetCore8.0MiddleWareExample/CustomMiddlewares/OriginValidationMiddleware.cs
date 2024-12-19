namespace DotNetCore8_MiddleWareExample
{ 
    public class OriginValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _allowedOrigins;
        private readonly ILogger<OriginValidationMiddleware> _logger;
        public OriginValidationMiddleware(RequestDelegate next, string[] allowedOrigins, ILogger<OriginValidationMiddleware> logger)
        {
            _next = next;
            _allowedOrigins = allowedOrigins;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("Origin", out var origin))
            {
                // Using Array.Exists
                bool exists = Array.Exists(_allowedOrigins, element => element == origin);
                // Validate the origin
                if (exists)
                {
                    _logger.LogWarning($"Blocked request from invalid origin: {origin}");
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden: Invalid Origin");
                    return;
                }
            }

            await _next(context);
        }
    }
}
