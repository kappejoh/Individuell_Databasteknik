using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class RoleFactory
    {
        public static Role? Map(RoleEntity entity) => entity == null ? null : new Role
        {
            Id = entity.Id,
            RoleName = entity.RoleName
        };
    }
}
