namespace Business.Models;

public class Tasks
{
    public int Id { get; set; }
    public string TaskTitle { get; set; } = null!;
    public string? Description { get; set; }
}
