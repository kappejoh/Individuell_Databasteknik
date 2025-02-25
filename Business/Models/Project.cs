using Data.Entities;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Status? Status { get; set; } = null!;

    public Customer? Customer { get; set; } = null!;

    public User? ProjectManager { get; set; } = null!;

    public Service? Service { get; set; } = null!;

    public ProjectType? ProjectType { get; set; } = null!;
}

