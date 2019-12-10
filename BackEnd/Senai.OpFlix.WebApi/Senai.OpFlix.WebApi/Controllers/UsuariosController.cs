using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository UsuarioRepository = new UsuarioRepository();

        /// <summary>
        /// VAI SERVIR PARA CRIAR UM MÉTODO ONDE APENAS O ADMINISTRADOR PODERÁ CADASTRAR OUTRO ADMINISTRADOR
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>    
        [HttpPost]
        // O POST SERVE PARA CADASTRAR UM NOVO ITEM 
        public IActionResult Cadastrar(UsuarioDomain usuario)
        {
            try
            {
                if (usuario.IdTipoUsuario == 2)
                {
                    return BadRequest(new { mensagem = "Erro: Você não possui a autorização necessária para cadastrar este tipo de usuário." });
                }
                    UsuarioRepository.Cadastrar(usuario);
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro: " + ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        // O GET SERVE PARA LISTAR OS RESULTADOS
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }
        
    }
}