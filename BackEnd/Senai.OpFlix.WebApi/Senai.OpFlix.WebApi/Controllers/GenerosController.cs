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

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        // O POST SERVE PARA CADASTRAR UM NOVO ITEM 
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            try
            {
                GeneroRepository.Cadastrar(genero);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro:" + ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        // O GET SERVE PARA LISTAR OS RESULTADOS
        public IActionResult Listar()
        {
            return Ok(GeneroRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            GeneroDomain Genero = GeneroRepository.BuscarPorId(id);
            if (Genero == null)
                return NotFound();
            return Ok(Genero);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        // O PUT SERVE PARA ALTERAR/ATUALIZAR UM NOVO ITEM
        public IActionResult Alterar(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = GeneroRepository.BuscarPorId(genero.IdGenero);
            
                if (generoBuscado == null)
                { 
                    return NotFound();
                }
                GeneroRepository.Alterar(genero);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }


    }
}