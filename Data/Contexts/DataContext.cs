using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public DbSet<AddressTypeEntity> AddressTypes { get; set; }
    public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<PostalCodeEntity> PostalCodes { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectTypeEntity> ProjectTypes { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<TaskAssignmentEntity> TaskAssignments { get; set; }
    public DbSet<TasksEntity> Tasks { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Hjälp från ChatGTP, främst med OnDelete-behavior
        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Status)
            .WithMany()
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.ProjectManager)
            .WithMany()
            .HasForeignKey(p => p.ProjectManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Service)
            .WithMany()
            .HasForeignKey(p => p.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.ProjectType)
            .WithMany()
            .HasForeignKey(p => p.ProjectTypeId)
            .OnDelete(DeleteBehavior.Restrict); 


        modelBuilder.Entity<TaskAssignmentEntity>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<TaskAssignmentEntity>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TaskAssignmentEntity>()
            .HasOne(x => x.Task)
            .WithMany(x => x.TaskAssignments)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InvoiceEntity>()
            .HasOne(x => x.Project)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InvoiceEntity>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserAddressEntity>()
            .HasOne(u => u.PostalCode)
            .WithMany()
            .HasForeignKey(u => u.PostalCodeId)
            .HasPrincipalKey(u => u.Id);


    }
}
