using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Status
{
    [Key]
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;
}
