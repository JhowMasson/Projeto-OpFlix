using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TipoMetragemDomain
    {
        public TipoMetragemDomain()
        {
            Lancamento = new HashSet<LancamentoDomain>();
        }

        public int IdTipoMetragem { get; set; }
        public string Nome { get; set; }

        public ICollection<LancamentoDomain> Lancamento { get; set; }
    }
}
