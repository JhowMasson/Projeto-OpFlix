using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TipoUsuarioRepository
    {
        public List<TipoUsuarioDomain> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TipoUsuario.ToList();
            }
        }

        public void Cadastrar(TipoUsuarioDomain tipoUsuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.TipoUsuario.Add(tipoUsuario);
                ctx.SaveChanges();
            }
        }
    }
}
