using System.Collections.Concurrent;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private static readonly ConcurrentDictionary<string, User> Users = new(StringComparer.OrdinalIgnoreCase);

    public Task Add(User user)
    {
        Users[user.Email] = user;
        return Task.CompletedTask;
    }

    public Task<User> GetUserByEmail(string email)
    {
        Users.TryGetValue(email, out var user);
        return Task.FromResult(user!);
    }
}
