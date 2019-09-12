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
                // LISTA TODAS OS LANCAMENTOS (SELECT * FROM LANCAMENTOS)
                return ctx.Lancamento.ToList();
            }
        }

        //CADASTRA NOVOS LANCAMENTOS
        public void Cadastrar(LancamentoDomain lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // CRIA A TABELA "Lancamento" (INSERT INTO)
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        //BUSCA O LANCAMENTO PELO ID 
        public LancamentoDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // IRÁ RETORNAR O VALOR, SE O ID QUE O USUÁRIO ENVIOU FOR IGUAL AO QUE ESTA NA TABELA
                return ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        //ATUALIZAR
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

        //DELETAR
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                LancamentoDomain LancamentoBuscado = ctx.Lancamento.Find(id);
                ctx.Lancamento.Remove(LancamentoBuscado);
                ctx.SaveChanges();
            }
        }

    }
}
