using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class User
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
    public Role? Role { get; set; } = null!;

    public ICollection<UserAddressEntity> UserAddresses { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
