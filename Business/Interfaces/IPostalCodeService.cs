using Business.Models;

namespace Business.Interfaces
{
    public interface IPostalCodeService
    {
        Task<IEnumerable<PostalCode?>> GetPostalCodesAsync();
    }
}