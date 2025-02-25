using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IEnumerable<User?>> GetUsersAsync()
    {
        var entities = await _userRepository.GetAllAsync();
        return entities.Select(UserFactory.Map);

    }
}
