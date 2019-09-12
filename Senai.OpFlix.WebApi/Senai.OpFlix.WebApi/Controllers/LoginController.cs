using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository UsuarioRepository = new UsuarioRepository();

        [HttpPost]
        public IActionResult Login (LoginViewModel login)
        {
            try
            {
                UsuarioDomain Usuario = UsuarioRepository.BuscarPorEmailESenha(login);
                if (Usuario == null)
                    return NotFound(new { mensagem = "Email e senha inválidos." });

                var claims = new[]
                {
                    //EMAIL
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    //ID
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Usuario.IdUsuario.ToString()),
                    // ESSA É A PERMISSÃO DO USUÁRIO
                    new Claim(ClaimTypes.Role, Usuario.IdTipoUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey
                    (System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    claims: claims, expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro." + ex.Message });
            }
        }
    }
}