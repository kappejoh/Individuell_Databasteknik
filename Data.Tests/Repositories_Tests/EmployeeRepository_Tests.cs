using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class EmployeeRepository_Tests
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
    public async Task GetEmployeesAsync_ShouldReturnAllEmployees()
    {
        // Arrange
        var context = GetDataContext();
        context.Employees.AddRange(TestData.EmployeeEntities);
        await context.SaveChangesAsync();

        IEmployeeRepository repository = new EmployeeRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.EmployeeEntities.Length, result.Count());
    }
}
