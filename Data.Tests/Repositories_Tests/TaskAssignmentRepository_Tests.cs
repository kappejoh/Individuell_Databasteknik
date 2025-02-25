using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class TaskAssignmentRepository_Tests
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
    public async Task GetTaskAssignmentsAsync_ShouldReturnAllTaskAssignments()
    {
        // Arrange
        var context = GetDataContext();
        context.TaskAssignments.AddRange(TestData.TaskAssignmentEntities);
        await context.SaveChangesAsync();

        ITaskAssignmentRepository repository = new TaskAssignmentRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.TaskAssignmentEntities.Length, result.Count());
    }
}
