using System;
using System.Net;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Infrastructure.NotFoundMiddleware;

public class NotFoundMiddleware
{
    private readonly RequestDelegate _next;

    public NotFoundMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception error)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";

            switch(error)
            {
                /*case AppException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;*/
                case KeyNotFoundException e: // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    httpContext.Response.Redirect("NotFound");
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }

    /*public async Task InvokeAsync(HttpContext httpContext)
    {
        Exception exception = Server.GetLastError();
        Response.Clear();

        HttpException httpException = exception as HttpException;

        //if (httpException != null)
        if(httpContext.)
        {
            switch (httpException.GetHttpCode())
            {
                case 404:
                    // page not found 
                    httpContext.Response.Redirect("default.aspx");
                    break;
                case 500:
                    // server error 
                    //routeData.Values.Add("action", "HttpError500");
                    break;
                default:
                    //routeData.Values.Add("action", "General");
                    break;
            }
        }
        string url = httpContext.Request.Path;
        if(url!="/")
        {
            string newurl = Environment.CurrentDirectory + url;
            Console.WriteLine(newurl);
            if (!File.Exists(newurl)) 
            {
                httpContext.Response.Redirect("/NotFound");
            }
        }
        await _next(httpContext);
    }*/
}

public static class UseNotFoundMiddlewareExtensions
{
    public static IApplicationBuilder UseNotFoundMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NotFoundMiddleware>();
    }
}