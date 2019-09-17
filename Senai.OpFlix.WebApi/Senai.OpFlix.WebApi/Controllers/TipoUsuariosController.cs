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
    public class TipoUsuariosController : ControllerBase
    {
        TipoUsuarioRepository TipoUsuarioRepository = new TipoUsuarioRepository();

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        // O GET SERVE PARA LISTAR OS RESULTADOS
        public IActionResult Listar()
        {
            return Ok(TipoUsuarioRepository.Listar());
        }

        [HttpPost]
        // O POST SERVE PARA CADASTRAR UM NOVO ITEM 
        public IActionResult Cadastrar(TipoUsuarioDomain tipoUsuario)
        {
            TipoUsuarioRepository.Cadastrar(tipoUsuario);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("id")]
        // O PUT SERVE PARA ALTERAR/ATUALIZAR UM NOVO ITEM
        public IActionResult Alterar(TipoUsuarioDomain tipoUsuario)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = TipoUsuarioRepository.BuscarPorId(tipoUsuario.IdTipoUsuario);
            if (tipoUsuarioBuscado == null)
                return NotFound();
            TipoUsuarioRepository.Alterar(tipoUsuario);
            return Ok();
        }
    }
}