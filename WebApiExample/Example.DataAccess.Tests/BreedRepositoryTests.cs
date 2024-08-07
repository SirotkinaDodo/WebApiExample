using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Example.DataAccess.Models;
using Example.DataAccess.Repositories;
using FluentAssertions;
using Xunit;

namespace Example.DataAccess.Tests;

public class BreedRepositoryTests : IClassFixture<TestDatabaseFixture>
{
    private readonly IFixture _fixture = new Fixture();
    private readonly IRepository<Breed> _repo;
    private readonly TestDatabaseFixture _testDatabaseFixture;

    public BreedRepositoryTests(TestDatabaseFixture testDatabaseFixture)
    {
        _testDatabaseFixture = testDatabaseFixture;
        _repo = new BreedRepository(_testDatabaseFixture.CreateContext());
    }

    [Fact]
    public async Task Create_ShouldAddBreedEntry()
    {
        // Arrange
        var testBreed = _fixture.Create<Breed>();

        // Act
        await _repo.Create(testBreed);

        // Assert
        var breeds = _repo.Get();

        breeds
            .Should()
            .Contain(x => x.Name == testBreed.Name);
    }

    [Fact]
    public async Task Delete_ShouldRemoveBreedEntry()
    {
        // Arrange
        var testData = _fixture.CreateMany<Breed>(3).ToList();
        foreach (var item in testData)
        {
            await _repo.Create(item);
        }
        //var breeds = _repo.Get();
        var name = testData.First().Name;
        var breedToRemove = _repo.Get(x => x.Name == name).First();

        // Act
        await _repo.Delete(breedToRemove);

        // Assert
        var breeds = _repo.Get();

        breeds.Should().NotContain(x => x.Name == testData.First().Name);
    }
}