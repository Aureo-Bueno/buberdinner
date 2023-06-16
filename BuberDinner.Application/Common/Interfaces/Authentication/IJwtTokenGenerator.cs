namespace BuberDinner.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(Guid userId, string firstName, string lastName);
}
