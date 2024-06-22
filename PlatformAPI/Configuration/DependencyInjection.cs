using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlatformAPI.Configuration.Domain;
using PlatformAPI.Configuration.Interface;
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
        services.AddScoped<IBadmintonCourtRepository, BadmintonCourtRepository>();
        services.AddScoped<IServiceCourtRepository, ServiceCourtRepository>();
        services.AddScoped<ICourtRepository, CourtRepository>();
        services.AddScoped<ISlotRepository, SlotRepository>();
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingStatusRepository, BookingStatusRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<ISlotStatusRepository, SlotStatusRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionStatusRepository, TransactionStatusRepository>();
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IBadmintonCourtService, BadmintonCourtService>();
        services.AddScoped<IServiceCourtService, ServiceCourtService>();
        services.AddScoped<ICourtService, CourtService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ISlotService, SlotService>();
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<Utilization>();
        services.AddScoped<IBookingStatusService, BookingStatusService>();
        services.AddScoped<ISlotStatusService, SlotStatusService>();
        services.AddScoped<ITransactionTypeService, TransactionTypeService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ITransactionStatusService, TransactionStatusService>();
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

    public static IServiceCollection AddSwaggerAuthorization(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "BadmintonRentalPlatform", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }

    public static IServiceCollection AddCloudinarySetting(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySettings"));
        return services;
    }
}