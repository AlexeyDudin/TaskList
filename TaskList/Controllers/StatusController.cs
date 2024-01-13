using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskList.Services;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : BaseController
    {

        private readonly ITaskApiService _taskApiService;
        public StatusController(ITaskApiService taskApiService) 
        {
            _taskApiService = taskApiService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return GetResponse(_taskApiService.GetStatuses());
        }
    }
}
