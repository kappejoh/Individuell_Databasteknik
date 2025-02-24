using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class Service
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerHour { get; set; }
}
