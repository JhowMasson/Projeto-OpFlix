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
    [ApiController]
    public class TipoMetragensController : ControllerBase
    {
        TipoMetragemRepository TipoMetragemRepository = new TipoMetragemRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TipoMetragemRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoMetragemDomain tipoMetregem)
        {
            TipoMetragemRepository.Cadastrar(tipoMetregem);
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult Alterar(TipoMetragemDomain tipoMetragem)
        {
            TipoMetragemDomain tipoMetragemBuscado = TipoMetragemRepository.BuscarPorId(tipoMetragem.IdTipoMetragem);
            if (tipoMetragemBuscado == null)
                return NotFound();
            TipoMetragemRepository.Alterar(tipoMetragem);
            return Ok();
        }
    }
}