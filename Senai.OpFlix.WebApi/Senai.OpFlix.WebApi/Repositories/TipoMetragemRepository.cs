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
                return ctx.TipoMetragem.ToList();
            }
        }

        public void Cadastrar(TipoMetragemDomain tipoMetragem)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.TipoMetragem.Add(tipoMetragem);
                ctx.SaveChanges();
            }
        }
    }
}
