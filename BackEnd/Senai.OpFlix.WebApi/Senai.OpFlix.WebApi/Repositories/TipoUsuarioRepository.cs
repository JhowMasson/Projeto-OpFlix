using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TipoUsuarioRepository
    {
        // LISTA OS TIPOS DE USUARIOS
        public List<TipoUsuarioDomain> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // LISTA TODOS OS TIPOS DE USUARIOS (SELECT * FROM TipoUsuario)
                return ctx.TipoUsuario.ToList();
            }
        }

        //CADASTRA NOVOS TIPOS DE USUARIOS
        public void Cadastrar(TipoUsuarioDomain tipoUsuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // CRIA A TABELA "TipoUsuario" (INSERT INTO)
                ctx.TipoUsuario.Add(tipoUsuario);
                ctx.SaveChanges();
            }
        }

        // BUSCA UM TIPO DE USUARIO PELO ID
        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id);
            }
        }

        // SERVE PARA ALTERAR/ATUALIZAR UM TIPO DE USUARIO
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
