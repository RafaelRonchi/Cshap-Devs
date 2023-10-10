using JWTAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Aluno")]
        [Authorize(Roles = "Aluno")]
        public IActionResult Alunos()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Bem Vindo: {currentUser.FullName} vc é um {currentUser.Role}");
        }

        [HttpGet("Diretor")]
        [Authorize(Roles = "Diretor")]
        public IActionResult Diretores()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Bem Vindo: {currentUser.FullName} vc é um {currentUser.Role}");
        }

        [HttpGet("Professor")]
        [Authorize(Roles = "Professor")]
        public IActionResult Professores()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Bem Vindo: {currentUser.FullName} vc é um {currentUser.Role}");
        }


        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null) {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    FullName = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
