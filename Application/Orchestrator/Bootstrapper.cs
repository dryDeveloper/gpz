using AuthServiceAdapter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        services.AddDbContext<GpzDbCtx>()
            .AddScoped(typeof(IRepositoryPort<>), typeof(EntityRepository<>))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IClientCreditRequestRepository, ClientCreditRequestRepository>()
            // TODO: complete Jwt implementation
            .AddScoped<IAuthToken, JwtToken>();

        return services;
    }
}
