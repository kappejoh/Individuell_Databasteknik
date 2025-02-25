using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentsController(ITaskAssignmentService taskAssignmentService) : ControllerBase
    {
        private readonly ITaskAssignmentService _taskAssignmentService = taskAssignmentService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskAssignmentService.GetTaskAssignmentsAsync();
            return Ok(result);
        }
    }
}
