using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Project?> CreateProjectAsync(ProjectRegistrationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var projectEntity = ProjectFactory.Map(form);

            if (projectEntity == null)
                return null;

            projectEntity = await _projectRepository.AddAsync(projectEntity);

            if (projectEntity == null)
                return null;

            var project = ProjectFactory.Map(projectEntity);
            return project;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Map);
        return projects;
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
        if (projectEntity == null)
            return null;

        var project = ProjectFactory.Map(projectEntity);
        return project;
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = ProjectFactory.Map(project);

            if (projectEntity == null)
                return false;

            var result = await _projectRepository.UpdateAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> RemoveProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = ProjectFactory.Map(project);

            if (projectEntity == null)
                return false;

            var result = await _projectRepository.RemoveAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    Task<bool> IProjectService.CreateProjectAsync(ProjectRegistrationForm form)
    {
        throw new NotImplementedException();
    }
}
