using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class CustomerAddressRepository_Tests
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
    public async Task GetCustomerAddressesAsync_ShouldReturnAllCustomerAddresses()
    {
        // Arrange
        var context = GetDataContext();
        context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
        await context.SaveChangesAsync();

        ICustomerAddressRepository repository = new CustomerAddressRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.CustomerAddressEntities.Length, result.Count());
    }
}
