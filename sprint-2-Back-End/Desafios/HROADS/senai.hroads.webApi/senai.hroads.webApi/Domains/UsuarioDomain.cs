using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public TipoDeUsuarioDomain TipoUsuario{ get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
