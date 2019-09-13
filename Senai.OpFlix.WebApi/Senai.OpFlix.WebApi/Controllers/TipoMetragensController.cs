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
    }
}