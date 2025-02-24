using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class Invoice
{
    public int Id { get; set; }

    public Project? Project { get; set; } = null!;

    public Customer? Customer { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    public bool Paid { get; set; }
}
