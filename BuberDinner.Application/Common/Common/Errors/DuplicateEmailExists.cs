using System.Net;

namespace BuberDinner.Application.Common.Common.Errors;

public class DuplicateEmailExists : Exception, IServiceExceptions
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already existes.";
}
