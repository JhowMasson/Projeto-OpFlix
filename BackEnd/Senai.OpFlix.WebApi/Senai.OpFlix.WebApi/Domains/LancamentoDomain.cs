using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class LancamentoDomain
    {
        public int IdLancamento { get; set; }
        public string Nome { get; set; }
        public TimeSpan? TempoDuracao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string Sinopse { get; set; }
        public int? IdGenero { get; set; }
        public int? IdTipoMetragem { get; set; }

        public GeneroDomain IdGeneroNavigation { get; set; }
        public TipoMetragemDomain IdTipoMetragemNavigation { get; set; }
    }
}
