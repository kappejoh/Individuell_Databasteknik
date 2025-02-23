using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int StatusTypeId { get; set; }

    public StatusTypeEntity StatusType { get; set; } = null!;
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int ProjectManagerId { get; set; }
    public UserEntity ProjectManager { get; set; } = null!;

    public int ArticleId { get; set; }
    public ArticleEntity Article { get; set; } = null!;

}