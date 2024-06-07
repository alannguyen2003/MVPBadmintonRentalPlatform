using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Interface;
using Service;
using Service.Interface;

namespace PlatformAPI.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value))
            };
        });
        return services;
    }

    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddScoped<Seeding>();
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}