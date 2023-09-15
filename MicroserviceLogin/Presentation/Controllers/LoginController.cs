using Application.DTOs.Response;
using Application.DTOs.Token;
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
        public IActionResult Register([FromBody] RegisterUser registerUser)
        {
            bool value = _userServices.RegisterUser(registerUser);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = value,
                Message = "Registrado correctamente"
            };

            IActionResult action = Ok(response);

            return action;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginUser loginUser)
        {
            TokenDto token = _userServices.Login(loginUser);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = "Registrado correctamente",
                Result = token
            };

            IActionResult action = Ok(response);

            return action;
        }

        
    }
}
