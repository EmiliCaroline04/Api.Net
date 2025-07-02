using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilmes.BaseDados.Models
{
    public partial class Avaliacao
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        public int Nota { get; set; }
        public string Comentario { get; set; }
        public DateTime DataAvaliacao { get; set; } = DateTime.Now;
    }
}
