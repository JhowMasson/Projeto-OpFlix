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

        public TipoMetragemDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TipoMetragem.FirstOrDefault(x => x.IdTipoMetragem == id);
            }
        }

        public void Alterar(TipoMetragemDomain tipoMetragem)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                TipoMetragemDomain TipoMetragemPesquisado = ctx.TipoMetragem.FirstOrDefault(x => x.IdTipoMetragem == tipoMetragem.IdTipoMetragem);
                TipoMetragemPesquisado.Nome = tipoMetragem.Nome;
                ctx.TipoMetragem.Update(TipoMetragemPesquisado);
                ctx.SaveChanges();
            }
        }

    }
}
