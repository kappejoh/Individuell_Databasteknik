using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<IEnumerable<Service?>> GetServicesAsync()
    {
        var entities = await _serviceRepository.GetAllAsync();
        return entities.Select(ServiceFactory.Map);

    }
}
