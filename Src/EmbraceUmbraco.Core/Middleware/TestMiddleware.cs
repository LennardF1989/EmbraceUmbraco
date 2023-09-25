using Microsoft.AspNetCore.Http;

namespace EmbraceUmbraco.Core.Middleware;

public class TestMiddleware
{
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/ping"))
        {
            context.Response.StatusCode = 200;
            context.Response.WriteAsync("Pong!");
            
            return;
        }
        
        await _next(context);
    }
}