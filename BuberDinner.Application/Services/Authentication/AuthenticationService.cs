namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    public async Task<AuthenticationResult> Login(string email, string password)
    {
        return await Task.FromResult(new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token"));
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        return await Task.FromResult(new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, "token"));
    }
}
