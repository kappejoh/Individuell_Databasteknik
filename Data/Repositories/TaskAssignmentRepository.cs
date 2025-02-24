using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class TaskAssignmentRepository(DataContext context) : BaseRepository<TaskAssignmentEntity>(context), ITaskAssignmentRepository
{
}
