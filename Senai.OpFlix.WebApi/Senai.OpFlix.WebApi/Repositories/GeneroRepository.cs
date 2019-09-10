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
        
    }
}
