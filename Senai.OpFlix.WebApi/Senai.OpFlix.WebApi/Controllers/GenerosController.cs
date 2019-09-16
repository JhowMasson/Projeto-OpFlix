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
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(GeneroRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            GeneroRepository.Cadastrar(genero);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Alterar(GeneroDomain genero)
        {
            GeneroDomain generoBuscado = GeneroRepository.BuscarPorId(genero.IdGenero);
            if (generoBuscado == null)
                return NotFound();
            GeneroRepository.Alterar(genero);
            return Ok();
        }

        // TODO - FAZER O DELETE DOS GENEROS
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }
    }
}