using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class AddressTypeService(IAddressTypeRepository addressTypeRepository) : IAddressTypeService
{
    private readonly IAddressTypeRepository _addressTypeRepository = addressTypeRepository;

    public async Task<IEnumerable<AddressType?>> GetAddressTypesAsync()
    {
        var entities = await _addressTypeRepository.GetAllAsync();
        return entities.Select(AddressTypeFactory.Map);

    }
}
