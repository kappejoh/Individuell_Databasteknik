using Business.Models;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? Map(ProjectRegistrationForm form) => form == null ? null : new()
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,
        ProjectManagerId = form.ProjectManagerId,
        ServiceId = form.ServiceId,
        ProjectTypeId = form.ProjectTypeId
    };

    public static ProjectEntity? Map(ProjectUpdate form) => form == null ? null : new()
    {
        Id = form.Id,
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        StatusId = form.StatusId,
        CustomerId = form.CustomerId,
        ProjectManagerId = form.ProjectManagerId,
        ServiceId = form.ServiceId,
        ProjectTypeId = form.ProjectTypeId
    };

    public static Project? Map(ProjectEntity entity) => entity == null ? null : new Project
    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Status = StatusFactory.Map(entity.Status),
        Customer = CustomerFactory.Map(entity.Customer),
        ProjectManager = UserFactory.Map(entity.ProjectManager),
        Service = ServiceFactory.Map(entity.Service),
        ProjectType = ProjectTypeFactory.Map(entity.ProjectType)
    };

    public static ProjectEntity? Map(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

                var entity = new ProjectEntity
                {
                    ProjectName = project.ProjectName,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    StatusId = project.Status!.Id,
                    CustomerId = project.Customer!.Id,
                    ProjectManagerId = project.ProjectManager!.Id,
                    ServiceId = project.Service!.Id,
                    ProjectTypeId = project.ProjectType!.Id

                };
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }

    }


}
