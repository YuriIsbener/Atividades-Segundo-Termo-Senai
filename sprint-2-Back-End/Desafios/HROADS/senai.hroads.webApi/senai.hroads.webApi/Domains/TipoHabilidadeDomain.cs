using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Domains
{
    public class TipoHabilidadeDomain
    {
        public int idTipoHabilidade { get; set; }

        [Required(ErrorMessage = "O nome do Tipo de Habilidade é obrigatório!")]
        public string NomeTipo { get; set; }
    }
}
