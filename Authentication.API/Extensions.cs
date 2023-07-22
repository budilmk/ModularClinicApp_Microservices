using Authentication.API.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.API;

public static class Extensions
{
    public static IServiceCollection AddAuthenticationModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services
            .AddClinicAuthentication(configuration)
            .AddTransient<JwtCreator>();
        return services;
    }
}