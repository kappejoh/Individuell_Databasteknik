using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services
{
    public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoicesService
    {
        private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;

        public async Task<IEnumerable<Invoice?>> GetInvoicesAsync()
        {
            var entities = await _invoiceRepository.GetAllAsync();
            return entities.Select(InvoiceFactory.Map);

        }
    }
}
