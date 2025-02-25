using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressTypesController(IAddressTypeService addressTypeService) : ControllerBase
{
    private readonly IAddressTypeService _addressTypeService = addressTypeService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _addressTypeService.GetAddressTypesAsync();
        return Ok(result);
    }
}
