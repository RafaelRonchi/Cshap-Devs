using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controlador : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Otarios");
        }

        [HttpGet("Aluno")]
        public IActionResult ola()
        {
            return BadRequest("Ola aluno");
        }
    }
}
