using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Domains
{
    public class ClasseDomain
    {
        public int IdClasse { get; set; }

        [Required(ErrorMessage = "O nome da Classe é obrigatório!")]
        public string NomeClasse { get; set; }
    }
}
