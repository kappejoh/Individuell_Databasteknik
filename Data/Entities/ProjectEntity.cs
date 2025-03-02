using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int ProjectManagerId { get; set; }
    public UserEntity ProjectManager { get; set; } = null!;

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;

    public int ProjectTypeId { get; set; }
    public ProjectTypeEntity ProjectType { get; set; } = null!;

    public ICollection<TaskAssignmentEntity> TaskAssignments { get; set; } = [];
    public ICollection<InvoiceEntity> Invoices { get; set; } = [];

}