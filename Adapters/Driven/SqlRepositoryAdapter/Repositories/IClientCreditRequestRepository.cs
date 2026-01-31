using Ports.Driven;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Repositories;

public interface IClientCreditRequestRepository : IRepositoryPort<ClientCreditRequestEntity> {
    Task<IEnumerable<ClientCreditRequestEntity>> FullCreditRequestDetails();
}
