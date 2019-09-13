using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class GeneroRepository
    {

        public List<GeneroDomain> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                // LISTA TODOS OS GENEROS (SELECT * FROM GENEROS)
                return ctx.Genero.ToList();
            }
        }

        //SERVE PARA CADASTRAR NOVOS GENEROS
        public void Cadastrar(GeneroDomain genero)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                // CRIA A TABELA "Genero" (INSERT INTO)
                ctx.Genero.Add(genero);
                ctx.SaveChanges();
            }
        }

        // BUSCA O GENERO PELO ID 
        public GeneroDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // IRÁ RETORNAR O VALOR, SE O ID QUE O USUARIO ENVIOU FOR IGUAL AO QUE ESTA NA TABELA
                return ctx.Genero.FirstOrDefault(x => x.IdGenero == id);
            }
        }

        // SERVE PARA ALTERAR/ATUALIZAR UM GENERO
        public void Alterar(GeneroDomain genero)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                GeneroDomain GeneroPesquisado = ctx.Genero.FirstOrDefault(x => x.IdGenero == genero.IdGenero);
                GeneroPesquisado.Nome = genero.Nome;
                ctx.Genero.Update(GeneroPesquisado);
                ctx.SaveChanges();
            }
        }
    }
}
