using System.Text;
using AuthServiceAdapter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ports.Driven;
using SqlRepositoryAdapter;
using SqlRepositoryAdapter.Repositories;

namespace Orchestrator;

public static class Bootstrapper {

    public static IServiceCollection BootstrapApp(this IServiceCollection services) {

        var basePath = Environment.CurrentDirectory;
        var cfg = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(
                "config.json", 
                optional: false, 
                reloadOnChange: false
            ).Build();

        services.AddSingleton(cfg);

        services.AddCors(opts => {
            opts.AddPolicy(
                name: "gpz_policy", 
                policy => policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );
        });

        services.AddAuthentication(opts => {
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtOpts => {
            jwtOpts.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = cfg.GetSection("api")["jwt:issuer"],
                ValidAudience = cfg.GetSection("api")["jwt:audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg.GetSection("api")["jwt:key"]!))
            };
        });
        services.AddAuthorization();

        services.AddDbContext<GpzDbCtx>()
            .AddScoped(typeof(IRepositoryPort<>), typeof(EntityRepository<>))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IClientCreditRequestRepository, ClientCreditRequestRepository>()
            .AddScoped<IAuthToken, JwtToken>()
            .AddScoped<IAuthServicePort, AuthServiceAdapter.AuthServiceAdapter>();

        return services;
    }
}
