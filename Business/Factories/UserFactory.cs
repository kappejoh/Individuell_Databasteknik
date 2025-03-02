using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class UserFactory
{
    public static User? Map(UserEntity entity) => entity == null ? null : new User
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        Password = entity.Password,
        SecurityKey = entity.SecurityKey,
        EmailConfirmed = entity.EmailConfirmed,
        Created = entity.Created,
        Modified = entity.Modified,
        Role = RoleFactory.Map(entity.Role),


    };
}
