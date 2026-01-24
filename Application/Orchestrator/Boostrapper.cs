using Microsoft.Extensions.DependencyInjection;
using SqlAdapter;
using SqlAdapter.Entities;
using SqlAdapter.Repositories;

namespace Orchestrator;

public static class Boostrapper {

    public static IServiceCollection BootstrapAppServices(this IServiceCollection services) {

        services.AddScoped<GpzDbContext>();

        services.AddScoped<IRepository<UserDto>, UserRepository>();

        return services;
    }

}
