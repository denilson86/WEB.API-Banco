using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WEB.API_Login.Models;

namespace WEB.API_Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Signin([FromBody] UserTokenDTO user)
        {
            if (user == null) return BadRequest("usuário ou senha inválidos");

            bool resultado = ValidateUser(user);
            if (resultado)
            {
                var tokenString = GenerateTokenJWT();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        // metodo para Gerar Token
        private string GenerateTokenJWT()
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                                expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        // metodo para validar usuário
        private bool ValidateUser(UserTokenDTO user)
        {
            if (user.User == "Admin" && user.Password == "@Dm!n.1122")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
