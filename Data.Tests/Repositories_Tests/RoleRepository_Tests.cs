using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class RoleRepository_Tests
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
    public async Task GetRolesAsync_ShouldReturnAllRoles()
    {
        // Arrange
        var context = GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();

        IRoleRepository repository = new RoleRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.RoleEntities.Length, result.Count());
    }
}
