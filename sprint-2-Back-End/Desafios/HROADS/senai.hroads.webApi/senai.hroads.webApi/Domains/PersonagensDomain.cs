using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Domains
{
    public class PersonagensDomain
    {
        public int idPersonagem { get; set; }
        public string NomePersonagem { get; set; }
        public ClasseDomain Classe { get; set; }
        public int CapacidadeVida { get; set; }
        public int CapacidadeMana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
