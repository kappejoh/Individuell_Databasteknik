using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodesController(IPostalCodeService postalCodeService) : ControllerBase
    {
        private readonly IPostalCodeService _postalCodeService = postalCodeService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postalCodeService.GetPostalCodesAsync();
            return Ok(result);
        }
    }
}
