using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioDomain usuario)
        {
            UsuarioRepository.Cadastrar(usuario);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = UsuarioRepository.BuscarPorId(usuario.IdUsuario);
            if (usuarioBuscado == null)
                return NotFound();
            UsuarioRepository.Alterar(usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        }
    }

}