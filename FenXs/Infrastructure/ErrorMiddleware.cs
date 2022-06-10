namespace Infrastructure.ErrorMiddleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next) { _next = next; }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);
        switch (httpContext.Response.StatusCode)
        {
            case 404:
                httpContext.Response.Redirect("/NotFound");
                break;
            case 500:
                //Nothing to do (now)...
                break;
            default:
                //Nothing to do...
                break;
        }
    }
}

public static class UseErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorMiddleware>();
    }
}