using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class UserAddressRepository_Tests
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
    public async Task GetUserAddressesAsync_ShouldReturnAllUserAddresses()
    {
        // Arrange
        var context = GetDataContext();
        context.UserAddresses.AddRange(TestData.UserAddressEntities);
        await context.SaveChangesAsync();

        IUserAddressRepository repository = new UserAddressRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.UserAddressEntities.Length, result.Count());
    }
}
