using MyGraphQl.Api.GraphQl.Queries;

namespace MyGraphQl.Api.IoC;

public static class ApiIoC
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();

        return services;
    }
}
