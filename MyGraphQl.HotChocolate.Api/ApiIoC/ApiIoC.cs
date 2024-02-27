using MyGraphQl.HotChocolate.Api.Queries;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.HotChocolate.Api.ApiIoC;

/// <summary>
/// Injects API services to the DI.
/// </summary>
public static class ApiIoC
{
    /// <summary>
    /// Injects API services to the DI.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
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
