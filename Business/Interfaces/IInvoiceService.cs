using Business.Models;

namespace Business.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice?>> GetInvoicesAsync();
    }
}