namespace Business.Models;

public class ProjectRegistrationForm
{
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int StatusNameId { get; set; }
    public int CustomerId { get; set; } 
    public int ProjectManagerId { get; set; } 
    public int ServiceId { get; set; }
    public int ProjectTypeId { get; set; }
}

