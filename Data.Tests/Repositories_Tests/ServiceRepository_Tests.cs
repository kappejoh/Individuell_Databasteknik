using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ServiceRepository_Tests
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
    public async Task GetServicesAsync_ShouldReturnAllServices()
    {
        // Arrange
        var context = GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        IServiceRepository repository = new ServiceRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.ServiceEntities.Length, result.Count());
    }
}
