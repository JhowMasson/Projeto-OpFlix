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

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id);
            }
        }

        public void Alterar(TipoUsuarioDomain tipoUsuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                TipoUsuarioDomain TipoUsuarioPesquisado = ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == tipoUsuario.IdTipoUsuario);
                TipoUsuarioPesquisado.Nome = tipoUsuario.Nome;
                ctx.TipoUsuario.Update(TipoUsuarioPesquisado);
                ctx.SaveChanges();
            }
        }
    }
}
