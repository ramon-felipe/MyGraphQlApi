using GraphQL;
using GraphQL.MicrosoftDI;
using MyGraphQl.Api.GraphQl;

namespace MyGraphQl.Api.IoC;

internal static class ApiIoC
{
    internal static IServiceCollection AddGraphQlServices(this IServiceCollection services)
    {
        return services
            .AddGraphQlOriginal();
    }

    private static IServiceCollection AddGraphQlOriginal(this IServiceCollection services)
    {
        return services
            .AddGraphQL(b => b.AddSystemTextJson())
            .AddScoped<GraphQL.Types.ISchema, MyGraphQlSchema>(services => new MyGraphQlSchema(new SelfActivatingServiceProvider(services)));
    }
}
