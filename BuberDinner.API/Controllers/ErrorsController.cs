using BuberDinner.Application.Common.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceExceptions serviceExceptions => ((int)serviceExceptions.StatusCode, serviceExceptions.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),
        };
        
        return Problem(statusCode: statusCode, title: message);
    }
}
