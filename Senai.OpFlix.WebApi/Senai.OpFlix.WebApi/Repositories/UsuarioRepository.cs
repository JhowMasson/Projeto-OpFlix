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

        public UsuarioDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id);
            }

        }

        public void Alterar(UsuarioDomain usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                UsuarioDomain UsuarioPesquisado = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
                UsuarioPesquisado.Nome = usuario.Nome;
                ctx.Usuario.Update(UsuarioPesquisado);
                ctx.SaveChanges();
            }

        }

        //TODO - FAZER O BuscarPorEmailESenha

    }
}
