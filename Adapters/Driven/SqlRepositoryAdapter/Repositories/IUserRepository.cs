using Ports.Driven;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Repositories;

public interface IUserRepository : IRepositoryPort<UserEntity> {
    Task<IEnumerable<UserEntity>> FullUserDetails();
}
