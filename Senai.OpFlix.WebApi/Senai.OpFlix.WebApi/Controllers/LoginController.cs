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

                // SÃO AS INFORMAÇÕES DO USUARIO
                var claims = new[]
                {
                    // EMAIL DO USUARIO
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    // ID DO USUARIO
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Usuario.IdUsuario.ToString()),
                    // ESSA É O TIPO DO USUÁRIO
                    new Claim(ClaimTypes.Role, Usuario.IdTipoUsuario.ToString()),
                };

                // ESSA CHAVE ESTA CONFIGURADA NO STARTUP
                var key = new SymmetricSecurityKey
                    (System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));
                // CRIPTOGRAFIA
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    // QUEM ESTA MANDANDO E QUEM ESTA VALIDANDO
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    // ESSA É A DATA DE EXPIRAÇÃO
                    claims: claims, expires: DateTime.Now.AddDays(30),
                    // ESSA É A CHAVE
                    signingCredentials: creds);


                // SERVE PARA GERAR AS CHAVES
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