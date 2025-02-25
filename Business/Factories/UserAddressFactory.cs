using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class UserAddressFactory
{
    public static UserAddress? Map(UserAddressEntity entity) => entity == null ? null : new UserAddress
    {
        Id = entity.Id,
        User = UserFactory.Map(entity.User),
        AddressType = AddressTypeFactory.Map(entity.AddressType),
        AddressLine_1 = entity.AddressLine_1,
        AddressLine_2 = entity.AddressLine_2,
        PostalCode = PostalCodeFactory.Map(entity.PostalCode)
    };
}

