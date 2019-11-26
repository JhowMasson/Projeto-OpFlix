using Microsoft.EntityFrameworkCore;
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
                // LISTA TODOS OS LANCAMENTOS (SELECT * FROM LANCAMENTOS)
                return ctx.Lancamento.Include(x => x.IdGeneroNavigation).Include(x => x.IdTipoMetragemNavigation).ToList(); //, x => x.idTipoMetragem
            }
        }

        // CADASTRA NOVOS LANCAMENTOS
        public void Cadastrar(LancamentoDomain lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // CRIA A TABELA "Lancamento" (INSERT INTO)
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        // BUSCA O LANCAMENTO PELO ID 
        public LancamentoDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // IRÁ RETORNAR O VALOR, SE O ID QUE O USUARIO ENVIOU FOR IGUAL AO QUE ESTA NA TABELA
                return ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        // SERVE PARA ALTERAR/ATUALIZAR UM LANCAMENTO
        public void Alterar(LancamentoDomain lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                LancamentoDomain LancamentoPesquisado = ctx.Lancamento.FirstOrDefault(X => X.IdLancamento == lancamento.IdLancamento);
                LancamentoPesquisado.Nome = lancamento.Nome;
                LancamentoPesquisado.Sinopse = lancamento.Sinopse;
                LancamentoPesquisado.TempoDuracao = lancamento.TempoDuracao;
                LancamentoPesquisado.DataLancamento = lancamento.DataLancamento;
                ctx.Lancamento.Update(LancamentoPesquisado);
                ctx.SaveChanges();
            }
        }

        // SERVE PARA DELETAR UM LANCAMENTO
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                LancamentoDomain Lancamento = ctx.Lancamento.Find(id);
                ctx.Lancamento.Remove(Lancamento);
                ctx.SaveChanges();
            }
        }

    }
}
