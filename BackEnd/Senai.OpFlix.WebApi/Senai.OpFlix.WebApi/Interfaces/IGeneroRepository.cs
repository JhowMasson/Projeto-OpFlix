using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IGeneroRepository
    {
        void Cadastrar(GeneroDomain genero);

        List<GeneroDomain> Listar();

        GeneroDomain BuscarPorId(int id);

        void Alterar(GeneroDomain genero);
    }
}
