using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class TasksRepository(DataContext context) : BaseRepository<TasksEntity>(context), ITasksRepository
{
}
