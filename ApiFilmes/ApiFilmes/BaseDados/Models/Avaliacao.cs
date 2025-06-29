using System;

namespace ApiFilmes.BaseDados.Models
{
    public partial class Avaliacao
    {
        public int Id { get; set; }

        // Chave estrangeira para Filme
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        // Campos principais
        public int Nota { get; set; }

        public string Comentario { get; set; }

        public DateTime DataAvaliacao { get; set; } = DateTime.Now;
    }
}
