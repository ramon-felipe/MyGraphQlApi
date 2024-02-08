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

    public async Task<User> GetUser(int id)
    {
        var user = await this._repository.GetByIdAsync(id);

        return user;

        //return user.HasValue ?
        //    user.Value :
        //    throw new KeyNotFoundException($"user (id: {id}) not found.");
    }
}
