using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskList.Dto.Models;
using TaskList.Services;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly IUserApiService _userApiService;

        public UserController(IUserApiService userApiService) 
        {
            _userApiService = userApiService;
        }

        [AllowAnonymous]
        [HttpPost, Route("Add")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            return GetResponse(_userApiService.AddUser(user));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUser([FromQuery] UserDto user)
        {
            return GetResponse(_userApiService.GetUser(user));
        }

        [HttpPost, Route("Delete")]
        public IActionResult DeleteUser([FromBody] UserDto user)
        {
            return GetResponse(_userApiService.DeleteUser(user));
        }

        [HttpPost, Route("Update")]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            return GetResponse(_userApiService.UpdateUser(user));
        }
    }
}
