using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class UserAddressService(IUserAddressRepository userAddressRepository) : IUserAddressService
{
    private readonly IUserAddressRepository _userAddressRepository = userAddressRepository;

    public async Task<IEnumerable<UserAddress?>> GetUserAddressesAsync()
    {
        var entities = await _userAddressRepository.GetAllAsync();
        return entities.Select(UserAddressFactory.Map);

    }
}
