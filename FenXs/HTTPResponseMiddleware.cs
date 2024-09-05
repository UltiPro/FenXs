namespace FenXs.HTTPResponseMiddleware;

public class HTTPResponseMiddleware
{
    private readonly RequestDelegate next;

    public HTTPResponseMiddleware(RequestDelegate next) { this.next = next; }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await next(httpContext);
        switch (httpContext.Response.StatusCode)
        {
            case 404:
                httpContext.Response.Redirect("/NotFound");
                break;
            case 500:
                httpContext.Response.Redirect("/Error");
                break;
        }
    }
}

public static class UseHTTPResponseMiddlewareExtensions
{
    public static IApplicationBuilder UseHTTPResponseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HTTPResponseMiddleware>();
    }
}