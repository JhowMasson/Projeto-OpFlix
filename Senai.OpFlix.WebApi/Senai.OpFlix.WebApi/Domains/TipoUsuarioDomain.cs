using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TipoUsuarioDomain
    {
        public TipoUsuarioDomain()
        {
            Usuario = new HashSet<UsuarioDomain>();
        }

        public int IdTipoUsuario { get; set; }
        public string Nome { get; set; }

        public ICollection<UsuarioDomain> Usuario { get; set; }
    }
}
