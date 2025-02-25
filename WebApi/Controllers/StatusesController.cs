﻿using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController(IStatusService statusService) : ControllerBase
    {
        private readonly IStatusService _statusService = statusService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _statusService.GetStatusesAsync();
            return Ok(result);
        }
    }
}
