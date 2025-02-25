using Business.Models;

namespace Business.Interfaces
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks?>> GetTasksAsync();
    }
}