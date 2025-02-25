using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class PostalCodeRepository_Tests
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
    public async Task GetPostalCodesAsync_ShouldReturnAllPostalCodes()
    {
        // Arrange
        var context = GetDataContext();
        context.PostalCodes.AddRange(TestData.PostalCodeEntities);
        await context.SaveChangesAsync();

        IPostalCodeRepository repository = new PostalCodeRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.PostalCodeEntities.Length, result.Count());
    }
}
