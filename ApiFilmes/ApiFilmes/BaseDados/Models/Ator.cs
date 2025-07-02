using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilmes.Models
{
    public class Ator
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
