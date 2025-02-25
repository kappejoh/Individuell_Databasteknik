using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerAddressFactory
{
    public static CustomerAddress? Map(CustomerAddressEntity entity) => entity == null ? null : new CustomerAddress
    {
        Id = entity.Id,
        Customer = CustomerFactory.Map(entity.Customer),
        AddressType = AddressTypeFactory.Map(entity.AddressType),
        AddressLine_1 = entity.AddressLine_1,
        AddressLine_2 = entity.AddressLine_2,
        PostalCode = PostalCodeFactory.Map(entity.PostalCode)
    };
}

