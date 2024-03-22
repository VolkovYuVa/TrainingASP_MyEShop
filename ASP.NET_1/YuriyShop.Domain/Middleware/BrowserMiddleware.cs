using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace YuriyShop.Domain.Middleware
{
    public class BrowserMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var browser = context.Request.Headers["User-Agent"].ToString();
            if (!browser.Contains("edge",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Response.StatusCode = 406;
                await context.Response.WriteAsync("Only Edge Prowser is allowed");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
