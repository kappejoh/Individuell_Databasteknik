using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class InvoiceEntity
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    public bool Paid { get; set; }
}

