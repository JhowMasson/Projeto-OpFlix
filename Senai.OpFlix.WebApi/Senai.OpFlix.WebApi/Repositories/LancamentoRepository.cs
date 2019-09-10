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

        public LancamentoDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        public void Alterar(LancamentoDomain lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                LancamentoDomain LancamentoPesquisado = ctx.Lancamento.FirstOrDefault(X => X.IdLancamento == lancamento.IdLancamento);
                LancamentoPesquisado.Nome = lancamento.Nome;
                ctx.Lancamento.Update(LancamentoPesquisado);
                ctx.SaveChanges();
            }
        }
    }
}
