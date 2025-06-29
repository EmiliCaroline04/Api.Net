using ApiFilmes.BaseDados.Models;
using System;
using System.Collections.Generic;

namespace ApiFilmes.Models
{
    public class Diretor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}
