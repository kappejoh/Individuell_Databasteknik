using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.SeedData;

public static class DataContextSeeder
{
    public static DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    public static async Task SeedAsync(DataContext context)
    {
        context.AddressTypes.AddRange(TestData.AddressTypeEntities);
        context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Employees.AddRange(TestData.EmployeeEntities);
        context.Invoices.AddRange(TestData.InvoiceEntities);
        context.PostalCodes.AddRange(TestData.PostalCodeEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypesEntities);
        context.Roles.AddRange(TestData.RoleEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.TaskAssignments.AddRange(TestData.TaskAssignmentEntities);
        context.Tasks.AddRange(TestData.TasksEntities);
        context.UserAddresses.AddRange(TestData.UserAddressEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
    }
    public static async Task SeedWithProjectsAsync(DataContext context)
    {
        context.AddressTypes.AddRange(TestData.AddressTypeEntities);
        context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.Employees.AddRange(TestData.EmployeeEntities);
        context.Invoices.AddRange(TestData.InvoiceEntities);
        context.PostalCodes.AddRange(TestData.PostalCodeEntities);
        context.Projects.AddRange(TestData.ProjectEntities);
        context.ProjectTypes.AddRange(TestData.ProjectTypesEntities);
        context.Roles.AddRange(TestData.RoleEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.TaskAssignments.AddRange(TestData.TaskAssignmentEntities);
        context.Tasks.AddRange(TestData.TasksEntities);
        context.UserAddresses.AddRange(TestData.UserAddressEntities);
        context.Users.AddRange(TestData.UserEntities);

        await context.SaveChangesAsync();
    }
}
