using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.API.Filters;
public class ErrorHandlingFilterAttributes : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        Exception exception = context.Exception;

        ProblemDetails problemDetails = new ProblemDetails 
        {
            Title = "An Error occured while processing you request.",
            Status = (int)HttpStatusCode.InternalServerError,
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}
