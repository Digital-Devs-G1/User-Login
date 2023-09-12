using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login()
        {
            IActionResult action = Ok();

            return action;
        }
    }
}
