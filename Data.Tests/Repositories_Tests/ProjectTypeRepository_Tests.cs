using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ProjectTypeRepository_Tests
{
    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    [Fact]
    public async Task GetProjectTypesAsync_ShouldReturnAllProjectTypes()
    {
        // Arrange
        var context = GetDataContext();
        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);
        await context.SaveChangesAsync();

        IProjectTypeRepository repository = new ProjectTypeRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.ProjectTypeEntities.Length, result.Count());
    }
}
