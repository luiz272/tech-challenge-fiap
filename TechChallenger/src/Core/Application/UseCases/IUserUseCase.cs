using Domain.Entities;

namespace Application.UseCases;

public interface IUserUseCase
{
    public IList<User> GetUsers();
}