using Business.Models;

namespace Business.Interfaces
{
    public interface IInvoicesService
    {
        Task<IEnumerable<Invoice?>> GetInvoicesAsync();
    }
}