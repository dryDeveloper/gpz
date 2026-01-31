using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ports.Driven;

namespace SqlRepositoryAdapter.Repositories;

public class EntityRepository<T>(GpzDbCtx ctx) : IRepositoryPort<T> where T : class{

    public GpzDbCtx Ctx { get; } = ctx;

    public async Task<int> CommitChanges() => await Ctx.SaveChangesAsync();

    public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate) => await Ctx.Set<T>()
        .Where(predicate)
        .ToArrayAsync();

    public async Task<IEnumerable<T>> ReadAllAsync() => await Ctx.Set<T>().ToArrayAsync();

    public async Task CreateAsync(T entity) => await Ctx.AddAsync(entity);

    public async Task CreateManyAsync(IEnumerable<T> entities) => await Ctx.AddRangeAsync(entities);

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate) => await Ctx.Set<T>()
        .Where(predicate)
        .ExecuteDeleteAsync() > 0;

    public async Task<bool> UpdateAsync(IEnumerable<T> entities) {
        Ctx.UpdateRange(entities);
        return await CommitChanges() > 0;
    }

}
