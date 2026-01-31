using BuberDinner.Application.Common.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        ILogger<AuthenticationService> logger)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        _logger.LogInformation("Login attempt for {Email}", email);

        if(await _userRepository.GetUserByEmail(email) is not User user)
        {
            _logger.LogWarning("Login failed for {Email}: user not found", email);
            throw new DuplicateEmailExists();
        }

        if(user.Password != password)
        {
            _logger.LogWarning("Login failed for {Email}: invalid password", email);
            throw new Exception("Invalid Password");
        }

        string token = await _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        _logger.LogInformation("Login succeeded for {Email}", email);
        return await Task.FromResult(new AuthenticationResult(user.Id, user.FirstName, user.LastName, email, token));
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        _logger.LogInformation("Register attempt for {Email}", email);

        if(await _userRepository.GetUserByEmail(email) is not null)
        {
            _logger.LogWarning("Register failed for {Email}: duplicate email", email);
            throw new Exception("User with given email already exists!");
        }

        User user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await _userRepository.Add(user);

        string token = await _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

        _logger.LogInformation("Register succeeded for {Email}", email);
        return await Task.FromResult<AuthenticationResult>(new AuthenticationResult(user.Id, firstName, lastName, email, token));
    }
}
