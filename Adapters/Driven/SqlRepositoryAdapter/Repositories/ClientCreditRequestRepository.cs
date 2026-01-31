using Microsoft.EntityFrameworkCore;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Repositories;

public class ClientCreditRequestRepository(GpzDbCtx ctx) : EntityRepository<ClientCreditRequestEntity>(ctx), IClientCreditRequestRepository {

    public async Task<IEnumerable<ClientCreditRequestEntity>> FullCreditRequestDetails() =>
        await Ctx.ClientCreditRequests
            .Include(c => c.PhoneNumbers)
            .Include(c => c.Addresses)
            .Include(c => c.PersonalReferences)
            .ToArrayAsync();

}
