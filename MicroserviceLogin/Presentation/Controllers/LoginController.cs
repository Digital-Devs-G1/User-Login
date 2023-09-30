using Application.DTOs.Response;
using Application.DTOs.Token;
using Application.DTOs.Users;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Handlers;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
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
                Message = "Registrado correctamente"
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            TokenDto token =  await _userServices.Login(loginUser);

            ResponseDto response = new ResponseDto()
            {
                Message = "Login correcto.",
                Result = token
            };

            return Ok(response); 
        }

        [HttpGet]
        [Route("GetUsers")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            List<GetUser> result = await _userServices.GetAllUsers(); 

            ResponseDto response = new ResponseDto()
            {
                Message = "",
                Result = result
            };

            return Ok(response); 
        }
    }
}
