using Business.Models;

namespace Business.Interfaces
{
    public interface IUserAddressService
    {
        Task<IEnumerable<UserAddress?>> GetUserAddressesTypeAsync();
    }
}