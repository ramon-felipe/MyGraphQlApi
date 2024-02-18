using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Api.DataLoaders;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.Api.GraphQl.Types;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        this.Field(_ => _.Id);
        this.Field(_ => _.Age);
        this.Field(_ => _.Name);
        this.Field(_ => _.LastName);

        this.Field<ListGraphType<UserProcessType>>("userProcesses")
            .Resolve()
            .WithScope()
            .WithService<IMyGraphQlContext>()
            .Resolve((ctx, service) => service.ProcessUserMapping.AsNoTracking().Where(_ => _.UserId == ctx.Source.Id).ToList());

        this.Field<ListGraphType<UserProcessType>>("userProcessesBatchLoader")
            .Resolve()
            .WithService<MyUserProcessMappingDataLoader>()
            .Resolve((ctx, loader) =>
            {
                return loader.LoadAsync(ctx.Source.Id);
            });
    }
}