using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuberDinner.API.Middleware;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode code = HttpStatusCode.InternalServerError;
        string result = JsonSerializer.Serialize(new { error = "An Error occured while processing you request." });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
