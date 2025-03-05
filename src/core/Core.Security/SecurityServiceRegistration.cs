using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security;

public static class SecurityServiceRegistration
{
    //IoC kaydini yapacak metot
    public static IServiceCollection AddSecurityDependencies(this IServiceCollection services)
    {

        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}