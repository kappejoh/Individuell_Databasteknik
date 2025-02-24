using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class AddressType
{
    [Key]
    public int Id { get; set; }
    public string AddressTypeValue { get; set; } = null!;
}
