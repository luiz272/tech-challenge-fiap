using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IList<User> _users = new List<User>
    {
        new User("Jônatas Alves", new CPF("123456789"))
    };

    public IList<User> GetUsers()
    {
        return _users.ToList();
    }
}