using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ImageProcessingApi.Controllers;

namespace ImageProcessingApi.Middleware
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

		
		public async Task InvokeAsync(HttpContext context)
		{
			var path = context.Request.Path.Value;

			// Allow unauthenticated access to static files and API key generation
			if (path != null && (
				path.StartsWith("/index.html") ||
				path.StartsWith("/css") ||
				path.StartsWith("/js") ||
				path.StartsWith("/images") ||
				path.StartsWith("/favicon.ico") ||
				path.StartsWith("/api/apikeys/generate")))
			{
				await _next(context);
				return;
			}

			var apiKey = context.Request.Headers["X-Api-Key"].ToString();
			if (string.IsNullOrWhiteSpace(apiKey) || !ApiKeysController.IsValidApiKey(apiKey))
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Invalid or missing API Key.");
				return;
			}

			await _next(context);
		}


	}
}

