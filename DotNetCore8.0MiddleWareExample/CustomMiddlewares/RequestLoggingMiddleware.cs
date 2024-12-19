using Serilog;

namespace DotNetCore8_MiddleWareExample
{
    public class RequestLoggingMiddleware
    {
        //RequestDelegate Process The HttpRequest.
        private readonly RequestDelegate _next;

        // Middleware constructor takes the next RequestDelegate in the pipeline
        /*
         * Each middleware can:
          Process the request itself.
          Pass it to the next middleware.
          Process the response after the next middleware completes.
         * 
         */
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;//Constructr Injection
        }

        // Invoke method handles each request and passes control to the next middleware


        public async Task InvokeAsync(HttpContext context)
        {
            /*
            2. How Middleware Works Internally?
          In ASP.NET Core, each middleware:
          Accepts an HttpContext.
          Either processes the request or forwards it to the next middleware.
          Performs some action on the response (optional)
            */
            // Log the request path
            Log.Information($"Request Path: {context.Request.Path}");
            Log.Information($"Request Path: {context.Request.Path}");
            await _next(context); // Process the next middleware in the pipeline
                                  // After the next middleware has completed, log the status code
            Log.Information($"Response Status Code: {context.Response.StatusCode}");
            Log.Information($"Response Status Code: {context.Response.StatusCode}");
        }
    }
}
