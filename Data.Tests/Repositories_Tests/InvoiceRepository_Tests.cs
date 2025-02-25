using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class InvoiceRepository_Tests
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
    public async Task GetInvoicesAsync_ShouldReturnAllInvoices()
    {
        // Arrange
        var context = GetDataContext();
        context.Invoices.AddRange(TestData.InvoiceEntities);
        await context.SaveChangesAsync();

        IInvoiceRepository repository = new InvoiceRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.InvoiceEntities.Length, result.Count());
    }
}