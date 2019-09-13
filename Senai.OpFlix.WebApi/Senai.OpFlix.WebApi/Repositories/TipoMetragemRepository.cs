using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TipoMetragemRepository
    {
        public List<TipoMetragemDomain> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // LISTA TODOS OS TIPOS DE METRAGENS (SELECT * FROM TipoMetragem)
                return ctx.TipoMetragem.ToList();
            }
        }
    }
}
