using System.Net;

namespace BuberDinner.Application.Common.Common.Errors;
public interface IServiceExceptions
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
