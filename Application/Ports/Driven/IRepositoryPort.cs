using System.Linq.Expressions;

namespace Ports.Driven;

public interface IRepositoryPort<T> {
    Task CreateAsync(T entity);
    Task CreateManyAsync(IEnumerable<T> entities);
    Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> ReadAllAsync();
    Task<bool> UpdateAsync(IEnumerable<T> entities);
    Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate);
    Task<int> CommitChanges();
}
