using Example.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess;

public sealed class ExampleContext : DbContext
{
    public DbSet<Dog> Dogs { get; set; }
    
    public DbSet<Owner> Owners { get; set; }
    
    public DbSet<Breed> Breeds { get; set; }
    
    public DbSet<OwnerDog> OwnersDogs { get; set; }

    public ExampleContext(DbContextOptions<ExampleContext> options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OwnerDog>().HasKey(od => new { od.DogId, od.OwnerId});
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExampleDb;Trusted_Connection=True;");
    }
}