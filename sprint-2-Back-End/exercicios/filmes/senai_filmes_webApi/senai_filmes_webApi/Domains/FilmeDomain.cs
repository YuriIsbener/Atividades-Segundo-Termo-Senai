﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    public class FilmeDomain
    {
        public int idFilmes { get; set; }
        public string titulo { get; set; }
        public int idGenero { get; set; }
    }
}
