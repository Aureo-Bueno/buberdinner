using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        if(await _userRepository.GetUserByEmail(email) is not User user) 
            throw new Exception("User with giver email already exixts!");

        if(user.Password != password)
            throw new Exception("Invalid Password");

        string token = await _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return await Task.FromResult(new AuthenticationResult(user.Id, user.FirstName, user.LastName, email, token));
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null) 
            throw new Exception("User with giver email already exixts!");

        User user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await _userRepository.Add(user);

        string token = await _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

        return await Task.FromResult<AuthenticationResult>(new AuthenticationResult(user.Id, firstName, lastName, email, token));
    }
}
