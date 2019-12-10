using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Cadastrar usuarios
        /// </summary>
        /// <param name="usuario"></param>
        // SERVE PARA CADASTRAR UM NOVO USUARIO
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        // IRÁ BUSCAR O USUARIO PELO SEU EMAIL E SUA SENHA
        public UsuarioDomain BuscarPorEmailESenha(LoginVIewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // IRÁ BUSCAR OS DADOS RECEBIDOS E VER SE O EMAIL E A SENHA SÃO IGUAIS
                UsuarioDomain usuario = ctx.Usuario.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }

        /// <summary>
        /// Cadastra um novo ADM
        /// </summary>
        /// <param name="usuario"></param>
        //SERVE PARA CADASTRAR UM NOVO ADMINISTRADOR
        public void CadastarADM(UsuarioDomain usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<UsuarioDomain> ListarUsuario()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuario.Include(x => x.IdTipoUsuarioNavigation).ToList();
            }
        }
    }
}
