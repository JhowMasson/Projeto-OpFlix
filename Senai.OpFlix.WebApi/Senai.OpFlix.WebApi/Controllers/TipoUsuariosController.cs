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
    public class TipoUsuariosController : ControllerBase
    {
        TipoUsuarioRepository TipoUsuarioRepository = new TipoUsuarioRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TipoUsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuarioDomain tipoUsuario)
        {
            TipoUsuarioRepository.Cadastrar(tipoUsuario);
            return Ok();
        }
    }
}