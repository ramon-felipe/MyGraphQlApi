using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.Api.DataLoaders;

// similar to BatchDataLoader
public class MyUserDataLoader : DataLoaderBase<int, User?>
{
    private readonly IMyGraphQlContext _dbContext;

    public MyUserDataLoader(IMyGraphQlContext dataContext)
    {
        _dbContext = dataContext;
    }

    protected override async Task FetchAsync(IEnumerable<DataLoaderPair<int, User?>> list, CancellationToken cancellationToken)
    {
        var ids = list.Select(pair => pair.Key);
        var data = await _dbContext
            .Users
            .AsNoTracking()
            .Include(_ => _.UserProcesses)
            .Where(u => ids.Contains(u.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);

        foreach (var entry in list)
        {
            entry.SetResult(data.TryGetValue(entry.Key, out var user) ? user : null);
        }
    }
}
