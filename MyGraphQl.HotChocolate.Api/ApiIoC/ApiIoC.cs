using MyGraphQl.HotChocolate.Api.Queries;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.HotChocolate.Api.ApiIoC;

public static class ApiIoC
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        return services
            .AddGraphQl();
    }

    private static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .RegisterDbContext<MyGraphQlContext>()
            .AddQueryType<CodeFirstQuery>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();

        return services;
    }
}
