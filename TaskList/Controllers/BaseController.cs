using Microsoft.AspNetCore.Mvc;
using TaskList.Dto.Response;

namespace TaskList.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult GetResponse(Result response)
        {
            return response.Code switch
            {
                ResponseStatus.Ok => Ok(response),
                ResponseStatus.Error => BadRequest(response),
                ResponseStatus.UserNotFound => Unauthorized(),
                _ => BadRequest(response)
            };
        }

    }
}
