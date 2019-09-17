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
    public class LancamentosController : ControllerBase
    {
        LancamentoRepository LancamentoRepository = new LancamentoRepository();
      
        [HttpGet]
        // O GET SERVE PARA LISTAR OS RESULTADOS
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        // O POST SERVE PARA CADASTRAR UM NOVO ITEM 
        public IActionResult Cadastrar(LancamentoDomain lancamento)
        {
            LancamentoRepository.Cadastrar(lancamento);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        // O PUT SERVE PARA ALTERAR/ATUALIZAR UM NOVO ITEM
        public IActionResult Alterar(LancamentoDomain lancamento)
        {
            LancamentoDomain lancamentoBuscado = LancamentoRepository.BuscarPorId(lancamento.IdLancamento);
            if (lancamentoBuscado == null)
                return NotFound();
            LancamentoRepository.Alterar(lancamento);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        // O DELETE SERVE PARA DELETAR UM ITEM 
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }
    }
}