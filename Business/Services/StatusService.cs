using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<IEnumerable<Status?>> GetStatusesAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        return entities.Select(StatusFactory.Map);

    }
}

