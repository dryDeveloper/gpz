using Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Ports.Driven;
using SqlRepositoryAdapter.Entities;
using SqlRepositoryAdapter.Mappers;
using SqlRepositoryAdapter.Repositories;

namespace RestApiAdapter.Endpoints;

public static class UserEndpoints {

    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app) {

        var group = app.MapGroup("users").WithParameterValidation();

        group.MapPost("login", [AllowAnonymous] async (IAuthServicePort authService, LoginRequestDto dto) => {
                var (authorized, response) = await authService.DoAuthAsync(
                    dto.Username, 
                    dto.Password
                );
                return Results.Ok(new { validCreds = authorized, payload = response });
        });

        group.MapGet("/", [Authorize] async (IUserRepository repo) => { 
            var entities = await repo.FullUserDetails();
            var dtos = entities.Select(e => new {
                e.Username,
                ProfileId = e.UserProfileId,
                ProfileName = e.UserProfile.Description,
                e.Firstname,
                e.Lastname
            });
            return Results.Ok(dtos);
        });

        group.MapPost("/", [Authorize] async (
            IRepositoryPort<UserEntity> userRepo, 
            IRepositoryPort<UserProfileEntity> profileRepo, 
            NewUserDto dto
        ) => {
            var profile = await profileRepo.FilterAsync(p => p.Id == dto.Profile);
            var newUserEntity = dto.ToEntity();
            if (profile is null)
                return Results.BadRequest("Non existing profile id");

            newUserEntity.UserProfile = profile.ToArray()[0];

            await userRepo.CreateAsync(newUserEntity);
            var changes = await userRepo.CommitChanges();

            if (changes != 0)
                return Results.Created();
            else
                return Results.BadRequest("no user was created, something bad happened...");
        });

        group.MapPost("/bulk", [Authorize] async (IRepositoryPort<UserEntity> repo, IEnumerable<NewUserDto> newUsers) => {
            var newUserEntities = newUsers.Select(u => new UserEntity {
                Username = u.UserName,
                Password = u.Password,
                Firstname = u.FirstName,
                Lastname = u.LastName
            });

            await repo.CreateManyAsync(newUserEntities);
            var changes = await repo.CommitChanges();

            if (changes > 0)
                return Results.Created();
            else
                return Results.BadRequest("no users were created, something bad happened...");
        });

        group.MapGet("hello", () => "Hello im a testing endpoint");

        return group;
    }
}
