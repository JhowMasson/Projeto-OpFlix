﻿using System;
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
    public class LancamentosController : ControllerBase
    {
        LancamentoRepository LancamentoRepository = new LancamentoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(LancamentoDomain lancamento)
        {
            LancamentoRepository.Cadastrar(lancamento);
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult Alterar(LancamentoDomain lancamento)
        {
            LancamentoDomain lancamentoBuscado = LancamentoRepository.BuscarPorId(lancamento.IdLancamento);
            if (lancamentoBuscado == null)
                return NotFound();
            LancamentoRepository.Alterar(lancamento);
            return Ok();
        }
    }
}