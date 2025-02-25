using Business.Models;
using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Business.Factories;

public static class CustomerFactory
{
    public static Customer? Map(CustomerEntity entity) => entity == null ? null : new Customer
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName
    };
}
