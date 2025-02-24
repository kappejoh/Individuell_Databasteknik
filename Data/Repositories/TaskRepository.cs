﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class TaskRepository(DataContext context) : BaseRepository<TaskEntity>(context), ITaskRepository
{
}
