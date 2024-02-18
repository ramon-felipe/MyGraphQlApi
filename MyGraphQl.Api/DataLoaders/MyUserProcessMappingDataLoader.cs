using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.Api.DataLoaders;

// similar to CollectionBatchDataLoader
public class MyUserProcessMappingDataLoader : DataLoaderBase<int, IEnumerable<ProcessUserMapping>>
{
    private readonly IMyGraphQlContext _dbContext;

    public MyUserProcessMappingDataLoader(IMyGraphQlContext dataContext)
    {
        _dbContext = dataContext;
    }

    protected override async Task FetchAsync(IEnumerable<DataLoaderPair<int, IEnumerable<ProcessUserMapping>>> list, CancellationToken cancellationToken)
    {
        var ids = list.Select(pair => pair.Key);
        var data = await _dbContext
            .ProcessUserMapping
            .AsNoTracking()
            .Include(_ => _.User)
            .Where(pu => ids.Contains(pu.UserId))
            .ToListAsync(cancellationToken);

        var dataLookup = data.ToLookup(x => x.UserId);

        foreach (var entry in list)
        {
            entry.SetResult(dataLookup[entry.Key]);
        }
    }
}