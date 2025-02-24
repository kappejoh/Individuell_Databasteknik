using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class UserAddress
{
    [Key]
    public int Id { get; set; }
    public User? User { get; set; } = null!;
    public AddressType? AddressType { get; set; } = null!;
    public string AddressLine_1 { get; set; } = null!;
    public string? AddressLine_2 { get; set; }
    public PostalCode? PostalCode { get; set; } = null!;
}
