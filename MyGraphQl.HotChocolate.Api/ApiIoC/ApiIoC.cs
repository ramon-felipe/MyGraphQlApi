using MyGraphQl.HotChocolate.Api.Queries;

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
            .AddQueryType<Query>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();

        return services;
    }
}
