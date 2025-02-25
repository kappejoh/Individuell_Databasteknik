using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services
{
    public class PostalCodeService(IPostalCodeRepository postalCodeRepository) : IPostalCodeService
    {
        private readonly IPostalCodeRepository _postalCodeRepository = postalCodeRepository;

        public async Task<IEnumerable<PostalCode?>> GetPostalCodesAsync()
        {
            var entities = await _postalCodeRepository.GetAllAsync();
            return entities.Select(PostalCodeFactory.Map);
        }
    }
}
