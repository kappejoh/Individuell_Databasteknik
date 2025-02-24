using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class StatusType
{
    [Key]
    public int Id { get; set; }
    public string StatusTypeValue { get; set; } = null!;
}
