using Business.Models;

namespace Business.Interfaces
{
    public interface ITaskAssignmentService
    {
        Task<IEnumerable<TaskAssignment?>> GetTaskAssignmentsAsync();
    }
}