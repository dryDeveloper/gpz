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

    public async Task<IEnumerable<(int, DateTime)>> RequestNumberAndDate() {
        var creditNoAndDate = await Ctx.ClientCreditRequests.ToArrayAsync();
        var requestNo = 0;
        var assignedOn = DateTime.Now;
        return creditNoAndDate.Select(i => (requestNo, assignedOn) = i);
        // return result;
    }
}
