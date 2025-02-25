namespace Data.Entities;

public class TasksEntity
{
    public int Id { get; set; }
    public string TaskTitle { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<TaskAssignmentEntity> TaskAssignments { get; set; } = [];
}
