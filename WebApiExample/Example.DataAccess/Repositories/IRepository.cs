namespace Example.DataAccess.Repositories;

public interface IRepository<T> where T : class
{
    Task Create(T item);
    
    Task Delete(T item);
    
    Task<T?> GetById(Guid id);

    IEnumerable<T> Get();
    
    IEnumerable<T> Get(Func<T, bool> predicate);
    
    Task Update(T item);
}