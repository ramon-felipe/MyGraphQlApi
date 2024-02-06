using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;

namespace MyGraphQl.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly IMyGraphQlContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(IMyGraphQlContext context)
    {
        this._context = context;
        this._dbSet = this._context.Set<T>();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        var task = Task.Run(() =>
        {
            return this._dbSet.AsNoTracking().AsEnumerable();
        });

        return task;
    }

    public Task<T> GetAsync(int id)
    {
        return this._dbSet.SingleOrDefaultAsync(_ => _.Id == id);
    }
}
