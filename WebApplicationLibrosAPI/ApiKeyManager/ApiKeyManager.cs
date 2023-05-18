using Microsoft.Extensions.Primitives;

namespace WebApplicationLibrosAPI.ApiKeyManager
{
    /// <summary>
    /// Class that handles a basic security layer for web API's
    /// </summary>
    public class ApiKeyManager
    {        
        private const string ApiKey = "MyApiKey";
        private readonly RequestDelegate _requestMiddleware;

        public ApiKeyManager(RequestDelegate requestMiddleware)
        {
            _requestMiddleware = requestMiddleware;
        }

        /// <summary>
        /// Method that checks whether a request includes the correct key credentials
        /// </summary>
        /// <param name="context">The http request</param>
        /// <returns>A http context with a corresponding status code</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKey, out StringValues apiKeyFromRequest))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey is not provided");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = appSettings.GetValue<string>(ApiKey);

            if (!apiKey.Equals(apiKeyFromRequest))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Error 401: Unauthorized client");
                return;
            }

            await _requestMiddleware(context);
        }
    }
}
