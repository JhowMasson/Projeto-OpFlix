using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        void Cadastrar(LancamentoDomain lancamento);

        List<LancamentoDomain> Listar();

        void Deletar(int id);

        LancamentoDomain BuscarPorId(int id);

        void Alterar(LancamentoDomain lancamento);

        List<LancamentoDomain> BuscarLancamentoPorGenero(int idGenero);
    }
}
