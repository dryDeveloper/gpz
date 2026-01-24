using Microsoft.EntityFrameworkCore;

namespace SqlAdapter.Repositories;

public class Repository<T>(GpzDbContext dbCtx) : IRepository<T> where T : class {

    internal readonly DbSet<T> TEntity = dbCtx.Set<T>();

    public Task CreateAsync(T entity) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(T entity) {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<T>> ReadAllAsync() {
        return await TEntity.ToArrayAsync();
    }

    public Task<T> ReadAsync() {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(T entity) {
        throw new NotImplementedException();
    }

}
