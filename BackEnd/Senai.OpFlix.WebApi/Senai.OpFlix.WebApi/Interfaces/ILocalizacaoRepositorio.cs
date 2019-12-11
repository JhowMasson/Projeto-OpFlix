using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
      public interface ILocalizacaoRepositorio
    {
        void Cadastrar(LocalizacaoDomain localizacoes);

        List<LocalizacaoDomain> Listar();
    }
}
