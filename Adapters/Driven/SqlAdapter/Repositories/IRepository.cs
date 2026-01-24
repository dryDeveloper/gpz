namespace SqlAdapter.Repositories;

public interface IRepository<T> {
    Task CreateAsync(T entity);
    Task<T> ReadAsync();
    Task<IReadOnlyCollection<T>> ReadAllAsync();
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}
