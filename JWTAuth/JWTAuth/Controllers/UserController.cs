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
        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Ola {currentUser.GivenName} vc é {currentUser.Role}");
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Ola {currentUser.GivenName} vc é {currentUser.Role}");
        }

        [HttpGet("AdminSellers")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdministratorSellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Ola {currentUser.GivenName} vc é {currentUser.Role}");
        }

        [HttpGet("Public")]
        [Authorize]
        public IActionResult Public()
        {
            return Ok("A");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null) {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
