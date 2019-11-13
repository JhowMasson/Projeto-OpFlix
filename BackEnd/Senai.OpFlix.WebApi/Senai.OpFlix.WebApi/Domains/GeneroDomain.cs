using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class GeneroDomain
    {
        public GeneroDomain()
        {
            Lancamento = new HashSet<LancamentoDomain>();
        }

        public int IdGenero { get; set; }
        public string Nome { get; set; }

        public ICollection<LancamentoDomain> Lancamento { get; set; }
    }
}
