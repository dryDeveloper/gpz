using Microsoft.EntityFrameworkCore;
using SqlAdapter.Entities;

namespace SqlAdapter.Repositories;

// TODO: add generic repo that implements IRepository<T> then extend it with this UserRepository
public class UserRepository(GpzDbContext dbCtx) : IRepository<UserDto> {

    public Task CreateAsync(UserDto entity) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(UserDto entity) {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<UserDto>> ReadAllAsync() {
        var users = await dbCtx.Users.ToArrayAsync();
        return users;
    }

    public Task<bool> UpdateAsync(UserDto entity) {
        throw new NotImplementedException();
    }

    Task<UserDto> IRepository<UserDto>.ReadAsync() {
        throw new NotImplementedException();
    }
}
