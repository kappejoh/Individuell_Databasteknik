using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class PostalCodeFactory
{
    public static PostalCode? Map(PostalCodeEntity entity) => entity == null ? null : new PostalCode
    {
        PostalCodeValue = entity.PostalCode,
        City = entity.City,
    };
}
