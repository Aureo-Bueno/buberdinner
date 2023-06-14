using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        AuthenticationResult result = await _authenticationService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);

        AuthenticationResponse response = new AuthenticationResponse(
            result.id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        AuthenticationResult result = await _authenticationService.Login(loginRequest.Email, loginRequest.Password);

        AuthenticationResponse response = new AuthenticationResponse(
            result.id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

        return Ok(response);
    }
}
