using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class CustomerAddressService(ICustomerAddressRepository customerAddressRepository) : ICustomerAddressService
{
    private readonly ICustomerAddressRepository _customerAddressRepository = customerAddressRepository;

    public async Task<IEnumerable<CustomerAddress?>> GetCustomerAddressesAsync()
    {
        var entities = await _customerAddressRepository.GetAllAsync();
        return entities.Select(CustomerAddressFactory.Map);

    }
}
