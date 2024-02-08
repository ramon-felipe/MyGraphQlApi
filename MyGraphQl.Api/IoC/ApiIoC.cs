using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using MyGraphQl.Api.GraphQl;

namespace MyGraphQl.Api.IoC;

public static class ApiIoC
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        return services
            .AddGraphQL(b => b
                .AddSystemTextJson())
            .AddSingleton<ISchema, MyGraphQlSchema>(services => new MyGraphQlSchema(new SelfActivatingServiceProvider(services)))
        ;
    }
}
