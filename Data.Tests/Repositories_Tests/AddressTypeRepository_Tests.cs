using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class AddressTypeRepository_Tests
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
    public async Task GetAddressTypesAsync_ShouldReturnAllAddressTypes()
    {
        // Arrange
        var context = GetDataContext();
        context.AddressTypes.AddRange(TestData.AddressTypeEntities);
        await context.SaveChangesAsync();

        IAddressTypeRepository repository = new AddressTypeRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.AddressTypeEntities.Length, result.Count());
    }
}
