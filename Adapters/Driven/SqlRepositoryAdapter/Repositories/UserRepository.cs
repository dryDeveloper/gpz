using Microsoft.EntityFrameworkCore;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Repositories;

public class UserRepository(GpzDbCtx ctx) : EntityRepository<UserEntity>(ctx), IUserRepository {

    public async Task<IEnumerable<UserEntity>> FullUserDetails() => 
        await Ctx.Users
            .Include(u => u.UserProfile)
            .ToArrayAsync();
}
