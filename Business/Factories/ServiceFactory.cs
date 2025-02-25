using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{
    public static Service? Map(ServiceEntity entity) => entity == null ? null : new Service
    {
        Id = entity.Id,
        ServiceName = entity.ServiceName,
        PricePerHour = entity.PricePerHour
    };
}
