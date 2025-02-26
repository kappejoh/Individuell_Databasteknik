using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ProjectRepository_Tests
{
    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    [Fact]
    public async Task AddAsync_Should_AddAndReturnProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Statuses.AddRange(TestData.StatusEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];

        // Act
        var result = await repository.AddAsync(projectEntity);

        // Assert
        Assert.NotEqual(0, result!.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjects()
    {
        // Arrange
        var context = GetDataContext();

        context.Statuses.AddRange(TestData.StatusEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.ProjectEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Statuses.AddRange(TestData.StatusEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        // Act
        var result = await repository.GetAsync(x => x.Id == 1);

        // Assert
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAndReturnProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Statuses.AddRange(TestData.StatusEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        var projectToUpdate = TestData.ProjectEntities.First();
        projectToUpdate.ProjectName = "Updated Project Name";

        // Act
        var updateResult = await repository.UpdateAsync(projectToUpdate);
        var updatedProject = await repository.GetAsync(x => x.Id == projectToUpdate.Id);

        // Assert
        Assert.True(updateResult); 
        Assert.NotNull(updatedProject); 
        Assert.Equal("Updated Project Name", updatedProject!.ProjectName); 
    }


    [Fact]
    public async Task RemoveAsync_ShouldRemoveProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Statuses.AddRange(TestData.StatusEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypeEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        var projectToRemove = TestData.ProjectEntities.First();
        var projectId = projectToRemove.Id;

        // Act
        var removeResult = await repository.RemoveAsync(projectToRemove);
        var retrievedProject = await repository.GetAsync(x => x.Id == projectId);

        // Assert
        Assert.True(removeResult);
        Assert.Null(retrievedProject);
    }


}
