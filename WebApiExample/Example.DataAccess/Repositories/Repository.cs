using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess.Repositories;

public class Repository<T>(ExampleContext context) : IRepository<T>
    where T : class
{
    private readonly ExampleContext _context = context;

    public async Task Create(T item)
    {
        await _context.Set<T>().AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
        _context.Set<T>().Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetById(Guid id)
        => await _context.Set<T>().FindAsync(id);

    public IEnumerable<T> Get()
        => _context.Set<T>().AsNoTracking();

    public IEnumerable<T> Get(Func<T, bool> predicate)
        => _context.Set<T>().AsNoTracking().AsEnumerable().Where(predicate);

    public async Task Update(T item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}