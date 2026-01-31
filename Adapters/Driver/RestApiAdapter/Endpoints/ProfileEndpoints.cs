using Ports.Driven;
using SqlRepositoryAdapter.Entities;

namespace RestApiAdapter.Endpoints;

public static class ProfileEndpoints {

    public static RouteGroupBuilder MapProfileEndpoints(this WebApplication app) {

        var group = app.MapGroup("profiles").WithParameterValidation();

        group.MapGet("/", async (IRepositoryPort<UserProfileEntity> repo) => {
            var entities = await repo.FilterAsync(e => true);
            var dtos = entities.Select(e => new { e.Description });
            return Results.Ok(dtos);
        });

        return group;
    }
}
