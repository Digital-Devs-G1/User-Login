using Application.DTOs.Users;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Login(RegisterUser registerUser)
        {
            string value = _userServices.RegisterUser(registerUser);
            IActionResult action = Ok(value);

            return action;
        }
    }
}
