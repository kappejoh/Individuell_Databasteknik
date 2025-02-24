namespace Data.Entities;

public class TaskAssignmentEntity
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;

    public int TaskId { get; set; }
    public TaskEntity Task { get; set; } = null!;

    public int EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;

    public DateTime AssignedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}