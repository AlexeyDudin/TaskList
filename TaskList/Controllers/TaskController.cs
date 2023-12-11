using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskList.Dto.Models;
using TaskList.Services;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : BaseController
    {
        private readonly ITaskApiService _taskApiService;

        public TaskController(ITaskApiService taskApiService)
        {
            _taskApiService = taskApiService;
        }

        [AllowAnonymous]
        [HttpGet, Route("active")]
        public IActionResult GetActiveTask()
        {
            return GetResponse(_taskApiService.GetActiveTask());
        }

        [AllowAnonymous]
        [HttpGet, Route("all")]
        public IActionResult GetAllTask()
        {
            return GetResponse(_taskApiService.GetAllTask());
        }

        [AllowAnonymous]
        [HttpPost, Route("add")]
        public IActionResult GetAllTask([FromBody] TaskDto newTask)
        {
            return GetResponse(_taskApiService.AddTask(newTask));
        }
    }
}
