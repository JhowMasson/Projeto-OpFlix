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
                return ctx.Genero.ToList();
            }
        }

        public void Cadastrar(GeneroDomain genero)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Genero.Add(genero);
                ctx.SaveChanges();
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Genero.FirstOrDefault(x => x.IdGenero == id);
            }
        }

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
