using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITasksService tasksService) : ControllerBase
    {
        private readonly ITasksService _tasksService = tasksService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tasksService.GetTasksAsync();
            return Ok(result);
        }
    }
}
