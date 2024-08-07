using Example.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess.Repositories;

public class BreedRepository : IRepository<Breed>
{
    private readonly ExampleContext _context;

    public BreedRepository(ExampleContext context)
    {
        _context = context;
    }

    public async Task Create(Breed item)
    {
        await _context.Breeds.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Breed item)
    {
        _context.Breeds.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Breed?> GetById(Guid id)
        => await _context.Breeds.FirstOrDefaultAsync(x => x.Id == id);

    public IEnumerable<Breed> Get()
        => _context.Breeds.AsNoTracking();

    public IEnumerable<Breed> Get(Func<Breed, bool> predicate)
        => _context.Breeds.AsNoTracking().AsEnumerable().Where(predicate);

    public async Task Update(Breed item)
    {
        _context.Breeds.Update(item);
        await _context.SaveChangesAsync();
    }
}