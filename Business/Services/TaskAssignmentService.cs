using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class TaskAssignmentService(ITaskAssignmentRepository taskAssignmentRepository) : ITaskAssignmentService
{
    private readonly ITaskAssignmentRepository _taskAssignmentRepository = taskAssignmentRepository;

    public async Task<IEnumerable<TaskAssignment?>> GetTaskAssignmentsAsync()
    {
        var entities = await _taskAssignmentRepository.GetAllAsync();
        return entities.Select(TaskAssignmentFactory.Map);
    }
}
