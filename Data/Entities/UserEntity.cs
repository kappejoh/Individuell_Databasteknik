using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string SecurityKey { get; set; } = null!;
    public bool EmailConfirmed { get; set; }

    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;

    public ICollection<UserRoleEntity> UserRoles { get; set; } = [];
    public ICollection<UserAddressEntity> UserAddresses { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}

