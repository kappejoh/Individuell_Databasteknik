using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class AddressTypeFactory
{
    public static AddressType? Map(AddressTypeEntity entity) => entity == null ? null : new AddressType
    {
        Id = entity.Id,
        AddressTypeValue = entity.AddressType
    };
}

