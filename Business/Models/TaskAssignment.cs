using Data.Entities;

namespace Business.Models;

public class TaskAssignment
{
    public int Id { get; set; }
    public Project? Project { get; set; } = null!;

    public Task? Task { get; set; } = null!;

    public Employee? Employee { get; set; } = null!;

    public DateTime AssignedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}
