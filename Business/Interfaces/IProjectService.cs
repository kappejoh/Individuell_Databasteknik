using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<Project?> CreateProjectAsync(ProjectRegistrationForm form);
        Task<Project?> GetProjectAsync(int id);
        Task<IEnumerable<Project?>> GetProjectsAsync();
        Task<bool> RemoveProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
    }
}