using JWTMedico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Medico medico = new Medico();

        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("cadastrar")]
        public ActionResult<Medico> Cadastrar(MedicoDTO mediicoDTO)
        {
            medico.Senha = mediicoDTO.Senha;
            medico.Email = mediicoDTO.Email;
            string crmHash = BCrypt.Net.BCrypt.HashPassword(mediicoDTO.CRM);
            medico.CRMHash = crmHash;

            return Ok(medico);
        }

        [HttpPost("login")]
        public ActionResult<Medico> Logar(MedicoDTO mediicoDTO)
        {
            if (mediicoDTO.Email is null) return BadRequest("O email não pode ser nulo");
            if (mediicoDTO.CRM is null) return BadRequest("O CRM não pode ser nulo");

            string token = CreateToken(mediicoDTO);
            return Ok(token);
        }

        private string CreateToken(MedicoDTO medico)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, medico.Email),
                new Claim(ClaimTypes.UserData, medico.CRM)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
               _config.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
