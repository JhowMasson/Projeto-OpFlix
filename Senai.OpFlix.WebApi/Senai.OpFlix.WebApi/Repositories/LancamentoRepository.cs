using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository
    {
        public List<LancamentoDomain> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.ToList();
            }
        }

        public void Cadastrar(LancamentoDomain lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }
    }
}
