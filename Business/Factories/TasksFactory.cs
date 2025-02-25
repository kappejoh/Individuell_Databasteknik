using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class TasksFactory
    {
        public static Tasks? Map(TasksEntity entity) => entity == null ? null : new Tasks
        {
            Id = entity.Id,
            TaskTitle = entity.TaskTitle,
            Description = entity.Description
        };
    }
}
