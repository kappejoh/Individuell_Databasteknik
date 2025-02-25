using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressesController(IUserAddressService userAddressService) : ControllerBase
    {
        private readonly IUserAddressService _userAddressService = userAddressService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userAddressService.GetUserAddressesAsync();
            return Ok(result);
        }
    }
}
