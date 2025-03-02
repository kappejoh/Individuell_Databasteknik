using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerAddressEntity 
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    public int AddressTypeId { get; set; }
    public AddressTypeEntity AddressType { get; set; } = null!;
    public string AddressLine_1 { get; set; } = null!;
    public string? AddressLine_2 { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PostalCodeId { get; set; }
    public PostalCodeEntity PostalCode { get; set; } = null!;

 
}

