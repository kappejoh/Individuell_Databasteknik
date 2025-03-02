using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectTypeEntity
{
    public int Id { get; set; }
    public string TypeName { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string PricingUnit { get; set; } = null!;
    
}
