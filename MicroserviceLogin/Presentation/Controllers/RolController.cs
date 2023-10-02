using Application.DTOs.Response;
using Application.DTOs.Rol;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public IActionResult GetAll() {

            IActionResult action;

            List<GetRol> result = _rolServices.GetAllRoles();

            ResponseDto response = new ResponseDto()
            {
                Result = result
            };

            action = Ok(response);

            return action;        
        }
    }
}
