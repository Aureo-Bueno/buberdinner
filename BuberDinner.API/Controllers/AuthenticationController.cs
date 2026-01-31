using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuberDinner.API.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(
        IAuthenticationService authenticationService,
        ILogger<AuthenticationController> logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        _logger.LogInformation("Register request received for {Email}", registerRequest.Email);
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
        _logger.LogInformation("Login request received for {Email}", loginRequest.Email);
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
