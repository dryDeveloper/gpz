using Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Ports.Driven;
using SqlRepositoryAdapter.Entities;
using SqlRepositoryAdapter.Mappers;

namespace RestApiAdapter.Endpoints;

public static class CreditRequestEndpoints
{
    public static RouteGroupBuilder MapCreditRequestEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("credit-requests").WithParameterValidation();

        group.MapGet(
            "/{creditRequestNumber}",
            [Authorize]
            async (IRepositoryPort<ClientCreditRequestEntity> repo, int creditRequestNumber) =>
            {
                var creditRequest = await repo.FilterAsync(c =>
                    c.RequestNumber == creditRequestNumber
                );
            }
        );

        group.MapPost(
            "/",
            [Authorize]
            async (
                IRepositoryPort<ClientCreditRequestEntity> repo,
                IEnumerable<NewCreditRequestDto> newCreditRequests
            ) =>
            {
                var newCreditRequestEntities = newCreditRequests.Select(dto => dto.ToEntity());
                await repo.CreateManyAsync(newCreditRequestEntities);
            }
        );

        return group;
    }
}
