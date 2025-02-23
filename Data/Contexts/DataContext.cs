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
    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<ArticlePriceListEntity> ArticlePriceLists { get; set; }
    public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<PostalCodeEntity> PostalCodes { get; set; }

    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRoleEntity>()
            .HasKey(x => new { x.UserId, x.RoleId });

        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
