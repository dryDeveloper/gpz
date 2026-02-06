using Microsoft.AspNetCore.Authorization;
using Ports.Driven;
using SqlRepositoryAdapter.Entities;

namespace RestApiAdapter.Endpoints;

public static class CreditRequestEndpoints {

    public static RouteGroupBuilder MapCreditRequestEndpoints(this WebApplication app) {
        
        var group = app.MapGroup("credit-requests").WithParameterValidation();

        group.MapGet("/{creditId}", [Authorize] async (IRepositoryPort<ClientCreditRequestEntity> repo) => {
            
        });

        return group;
    }
}
