using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    IList<User> GetUsers();
}