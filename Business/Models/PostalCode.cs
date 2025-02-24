using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class PostalCode
{
    public string PostalCodeValue { get; set; } = null!;
    public string City { get; set; } = null!;
}
