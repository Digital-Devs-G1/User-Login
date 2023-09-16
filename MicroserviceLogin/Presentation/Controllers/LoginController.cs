using Application.DTOs.Response;
using Application.DTOs.Token;
using Application.DTOs.Users;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            bool value = await _userServices.RegisterUser(registerUser);

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
                Message = "Login correcto.",
                Result = token
            };

            IActionResult action = Ok(response);

            return action;
        }

        [HttpGet]
        [Route("GetUsers")]
        [Authorize]
        public IActionResult GetAll()
        {
            IActionResult action;

            List<GetUser> result = _userServices.GetAllUsers(); 

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = "",
                Result = result
            };

            action = Ok(response);

            return action;
        }
    }
}
