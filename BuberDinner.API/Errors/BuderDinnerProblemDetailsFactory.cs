using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

namespace BuberDinner.API.Errors;
public class BuderDinnerProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public BuderDinnerProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext, 
        int? statusCode = null, 
        string? title = null, 
        string? type = null, 
        string? detail = null, 
        string? instance = null)
    {
        statusCode ??= 500;

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title, 
            Type = type, 
            Detail = detail, 
            Instance = instance
        };

        ApplyProblemDetailsDefault(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemDetailsDefault(HttpContext httpContext, ProblemDetails problemDetails)
    {
        problemDetails.Status ??= statusCode;

        if(_options.ClientErrorMapping.TryGetValue(StatusCodePagesExtensions, out var clientErrorData))
        {

        }
    }
}
