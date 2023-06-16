using System.Net;

namespace BuberDinner.Application.Common.Common.Errors;
public interface IServiceExceptions
{
    public HttpStatusCode StatusCode { get; set; }
    public string ErrorMessage { get; set; }
}
