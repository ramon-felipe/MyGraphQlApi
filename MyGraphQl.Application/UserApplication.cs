using MyGraphQl.Domain;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Application;

public interface IUserApplication
{
    Task<User> GetUser(int id);
}

public class UserApplication : IUserApplication
{
    private readonly IGenericRepository<User> _repository;

    public UserApplication(IGenericRepository<User> repository)
    {
        this._repository = repository;
    }

    public Task<User> GetUser(int id)
    {
        return this._repository.GetAsync(id);
    }
}
