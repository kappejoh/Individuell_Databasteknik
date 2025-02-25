using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class InvoiceFactory
{
    public static Invoice? Map(InvoiceEntity entity) => entity == null ? null : new Invoice
    {
        Id = entity.Id,
        Project = ProjectFactory.Map(entity.Project),
        Customer = CustomerFactory.Map(entity.Customer),
        InvoiceDate = entity.InvoiceDate,
        DueDate = entity.DueDate,
        TotalAmount = entity.TotalAmount,
        Paid = entity.Paid
    };
}
