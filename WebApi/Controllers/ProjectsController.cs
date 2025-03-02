using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> CreateProject(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        Console.WriteLine("Validation Errors: " + string.Join(", "));

        var project = await _projectService.CreateProjectAsync(form);
        return project == null ? BadRequest() : Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, ProjectUpdate project)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedProject = await _projectService.UpdateProjectAsync(project);
        return updatedProject != null ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);

        if (project == null)
            return NotFound();

        var deletedProject = await _projectService.RemoveProjectAsync(project);
        return deletedProject ? Ok() : BadRequest();
    }
}
