using GraphQL;
using GraphQL.MicrosoftDI;
using MyGraphQl.Api.DataLoaders;
using MyGraphQl.Api.GraphQl;

namespace MyGraphQl.Api.IoC;

internal static class ApiIoC
{
    internal static IServiceCollection AddGraphQlServices(this IServiceCollection services)
    {
        return services
            .AddGraphQlOriginal()
            .AddGraphQlDataLoaders()
        ;
    }

    private static IServiceCollection AddGraphQlOriginal(this IServiceCollection services)
    {
        return services
            .AddGraphQL(b => b
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true))
            .AddSingleton<GraphQL.Types.ISchema>(services => new MyGraphQlSchema(new SelfActivatingServiceProvider(services)))
        ;
    }

    private static IServiceCollection AddGraphQlDataLoaders(this IServiceCollection services)
    {
        return services
            .AddScoped<MyUserDataLoader>()
            .AddScoped<MyUserProcessMappingDataLoader>()
        ;
    }
}
