using SqlAdapter.Entities;
using SqlAdapter.Repositories;

namespace RestApiAdapter.Endpoints;

public static class UserEndpoints {

    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app) {

        var group = app.MapGroup("users").WithParameterValidation();

        group.MapGet("/", async (IRepository<UserDto> repo) => {
            return Results.Ok(await repo.ReadAllAsync());
        });

        group.MapGet("/hello", (IGreetService service) => service.Greet());

        return group;
    }
}

public interface IGreetService {
    string Greet();
}

public class GreetService : IGreetService {
    public string Greet() {
        return "Hello buddy";
    }
}
