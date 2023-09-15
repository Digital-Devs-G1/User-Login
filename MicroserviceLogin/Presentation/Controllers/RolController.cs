using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        [HttpGet]
        [Route("GetAllRoles")]
        public IActionResult GetAll() {






            return Ok();
        
        }
    }
}
