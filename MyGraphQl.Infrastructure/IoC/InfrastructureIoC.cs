using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Infrastructure.IoC;
public static class InfrastructureIoC
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connString = "Server=(localdb)\\MSSQLLocalDB;Database=MyGraphQl;Trusted_Connection=True";

        return services
            .AddDbContext<MyGraphQlContext>(options =>
            {
                options
                .UseSqlServer(connString);
            }, contextLifetime: ServiceLifetime.Singleton)
            .AddSingleton<IMyGraphQlContext, MyGraphQlContext>()
            .AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            ;
    }
}
