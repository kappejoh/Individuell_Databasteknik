using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ServiceEntity
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerHour { get; set; }

    
}

