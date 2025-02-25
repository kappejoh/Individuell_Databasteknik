using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class TasksRepository_Tests
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
    public async Task GetTasksAsync_ShouldReturnAllTasks()
    {
        // Arrange
        var context = GetDataContext();
        context.Tasks.AddRange(TestData.TasksEntities);
        await context.SaveChangesAsync();

        ITasksRepository repository = new TasksRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.TasksEntities.Length, result.Count());
    }
}
