using Microsoft.Extensions.DependencyInjection;

namespace MyGraphQl.Application.IoC;
public static class ApplicationIoC
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        return services.AddTransient<IUserApplication, UserApplication>()
            ;
    }
}
