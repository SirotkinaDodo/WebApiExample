using System;
using Example.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess.Tests;

public class TestDatabaseFixture
{
    private const string ConnectionString =
        @"Server=(localdb)\mssqllocaldb;Database=EFTestDb;Trusted_Connection=True;ConnectRetryCount=0";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    context.AddRange(
                        new Breed { Name = "Saint Bernard", CreatedTimestamp = DateTime.Now },
                        new Owner { FirstName = "Jack", SecondName = "Fosters", CreatedTimestamp = DateTime.Now });
                    context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public ExampleContext CreateContext()
    {
        return new ExampleContext(
            new DbContextOptionsBuilder<ExampleContext>()
                .UseSqlServer(ConnectionString)
                .Options);
    }
}