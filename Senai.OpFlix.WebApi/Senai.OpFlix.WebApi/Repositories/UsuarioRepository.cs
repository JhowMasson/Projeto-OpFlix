using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository
    {
        /// <summary>
        /// Lista os Usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDomain> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // LISTA TODOS OS USUARIOS
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
        // BUSCA OS USUARIOS PELO ID 
        public UsuarioDomain BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id);
            }

        }


        // TODO - ADCIONAR AS OUTRAS PROPRIEDADES PARA FAZER A ALTERAÇÃO NO POSTMAN
        // SERVE PARA ALTERAR/ATUALIZAR UM USUARIO
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

        // IRÁ BUSCAR O USUARIO PELO SEU EMAIL E SUA SENHA
        public UsuarioDomain BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // IRÁ BUSCAR OS DADOS RECEBIDOS E VER SE O EMAIL E A SENHA SÃO IGUAIS
                UsuarioDomain UsuarioBuscado = ctx.Usuario.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }

        // SERVE PARA DELETAR UM USUARIO
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                UsuarioDomain Usuario = ctx.Usuario.Find(id);
                ctx.Usuario.Remove(Usuario);
                ctx.SaveChanges();
            }
        }

        


    }
}
