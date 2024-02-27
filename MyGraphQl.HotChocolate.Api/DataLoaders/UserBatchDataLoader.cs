using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.HotChocolate.Api.DataLoaders;

/// <summary>
/// User data loader.
/// </summary>
public class UserBatchDataLoader : BatchDataLoader<int, User>
{
    private readonly IMyGraphQlContext _myGraphQlContext;

    /// <summary>
    /// User data loader.
    /// </summary>
    /// <param name="myGraphQlContext"></param>
    /// <param name="batchScheduler"></param>
    /// <param name="options"></param>
    public UserBatchDataLoader(IMyGraphQlContext myGraphQlContext, IBatchScheduler batchScheduler, DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        this._myGraphQlContext = myGraphQlContext;
    }

    /// <summary>
    /// Loads all the users
    /// </summary>
    /// <param name="keys"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// 
    protected override async Task<IReadOnlyDictionary<int, User>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        // instead of fetching one person, we fetch multiple persons
        return await this._myGraphQlContext
            .Users
            .AsNoTracking()
            .Include(_ => _.UserProcesses)
            .ThenInclude(_ => _.Process)
            .Where(_ => keys.Contains(_.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken: cancellationToken);
    }
}