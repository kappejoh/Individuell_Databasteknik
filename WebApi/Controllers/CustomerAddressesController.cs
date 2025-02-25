using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController(ICustomerAddressService customerAddressService) : ControllerBase
    {
        private readonly ICustomerAddressService _customerAddressService = customerAddressService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerAddressService.GetCustomerAddressesAsync();
            return Ok(result);
        }
    }
}
