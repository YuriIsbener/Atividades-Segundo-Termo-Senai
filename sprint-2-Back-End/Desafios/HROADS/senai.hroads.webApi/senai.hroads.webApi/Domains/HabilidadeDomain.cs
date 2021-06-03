using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Domains
{
    public class HabilidadeDomain
    {
        public int idHabilidade { get; set; }
        public TipoHabilidadeDomain TH { get; set; }
        public string NomeHabilidade { get; set; }
    }
}
