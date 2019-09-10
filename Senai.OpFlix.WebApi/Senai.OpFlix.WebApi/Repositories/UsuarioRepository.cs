using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public List<UsuarioDomain> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuario.ToList();
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }
}
