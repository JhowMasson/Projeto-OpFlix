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

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        // O GET SERVE PARA LISTAR OS RESULTADOS
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }
        /// <summary>
        /// VAI SERVIR PARA CRIAR UM MÉTODO ONDE APENAS O ADMINISTRADOR PODERÁ CADASTRAR OUTRO ADMINISTRADOR
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>    
        [HttpPost]
        // O POST SERVE PARA CADASTRAR UM NOVO ITEM 
        public IActionResult Cadastrar(UsuarioDomain usuario)
        {
            if (usuario.IdTipoUsuario == 2)
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            else
            {
                return BadRequest(new { mensagem = "Você não possui a autorização necessária para cadastrar este tipo de usuário." });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        // O PUT SERVE PARA ALTERAR/ATUALIZAR UM NOVO ITEM
        public IActionResult Alterar(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = UsuarioRepository.BuscarPorId(usuario.IdUsuario);
            if (usuarioBuscado == null)
                return NotFound();
            UsuarioRepository.Alterar(usuario);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        // O DELETE SERVE PARA DELETAR UM ITEM 
        public IActionResult Deletar(int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        }       
    }
}