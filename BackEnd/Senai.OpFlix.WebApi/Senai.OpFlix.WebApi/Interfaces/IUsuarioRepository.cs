using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarPorEmailESenha(LoginVIewModel login);

        void CadastarADM(UsuarioDomain usuario);

        void Cadastrar(UsuarioDomain usuario);

        List<UsuarioDomain> ListarUsuario();

    }
}
