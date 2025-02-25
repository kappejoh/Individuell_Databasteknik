using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class TaskAssignmentFactory
{
    public static TaskAssignment? Map(TaskAssignmentEntity entity) => entity == null ? null : new TaskAssignment
    {
        Id = entity.Id,
        Project = ProjectFactory.Map(entity.Project),
        Task = TasksFactory.Map(entity.Task),
        Employee = EmployeeFactory.Map(entity.Employee),
        AssignedDate = entity.AssignedDate,
        CompletedDate = entity.CompletedDate

    };
}
