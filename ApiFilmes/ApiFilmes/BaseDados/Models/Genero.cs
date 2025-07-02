using ApiFilmes.BaseDados.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilmes.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}
