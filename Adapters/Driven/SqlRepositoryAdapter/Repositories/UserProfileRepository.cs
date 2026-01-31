using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ports.Driven;
using SqlRepositoryAdapter.Entities;

namespace SqlRepositoryAdapter.Repositories;

public class UserProfileRepository(GpzDbCtx ctx) : IRepositoryPort<UserProfileEntity> {

    public async Task<int> CommitChanges() => await ctx.SaveChangesAsync();
    // public async Task<IEnumerable<UserProfileEntity>> ReadAllAsync() => await ctx.UserProfiles.ToArrayAsync();
    public async Task CreateAsync(UserProfileEntity entity) => await ctx.AddAsync(entity);
    public async Task CreateManyAsync(IEnumerable<UserProfileEntity> entities) => await ctx.AddRangeAsync(entities);

    // public Task<bool> DeleteAsync(UserProfileEntity entity) {
    //     throw new NotImplementedException();
    // }

    public Task<bool> DeleteAsync(Expression<Func<UserProfileEntity, bool>> predicate) {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserProfileEntity>> ReadAllAsync() => await ctx.UserProfiles.ToArrayAsync();

    public Task<IEnumerable<UserProfileEntity>> FilterAsync(Expression<Func<UserProfileEntity, bool>> predicate) {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(IEnumerable<UserProfileEntity> entities) {
        throw new NotImplementedException();
    }
}
