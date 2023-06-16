using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    public Task Add(User user)
    {
    }

    public Task<User> GetUserByEmail(string email)
    {
    }
}
