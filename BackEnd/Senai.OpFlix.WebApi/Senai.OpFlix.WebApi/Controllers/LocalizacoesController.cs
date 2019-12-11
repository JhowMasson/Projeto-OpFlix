using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacoesController : ControllerBase
    {
        public ILocalizacaoRepositorio LocalizacaoRepositorio { get; set; }

        public LocalizacoesController()
        {
            LocalizacaoRepositorio = new LocalizacaoRepositorio();
        }

        [HttpPost]
        public IActionResult Cadastrar(LocalizacaoDomain localizacoes)
        {
            try
            {
                LocalizacaoRepositorio.Cadastrar(localizacoes);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(LocalizacaoRepositorio.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
        }

    }
}