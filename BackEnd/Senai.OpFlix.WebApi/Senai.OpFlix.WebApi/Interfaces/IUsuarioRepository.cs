using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarPorEmailESenha(LoginViewModel login);

        void CadastarADM(UsuarioDomain usuario);

        void Cadastrar(UsuarioDomain usuario);

        List<UsuarioDomain> ListarUsuario();

    }
}
