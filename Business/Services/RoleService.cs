using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<IEnumerable<Role?>> GetRolesAsync()
    {
        var entities = await _roleRepository.GetAllAsync();
        return entities.Select(RoleFactory.Map);

    }
}
