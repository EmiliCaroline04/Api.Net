using System;

namespace ApiFilmes.DTOs
{
    public class AvaliacaoDTO
    {
        public int FilmeId { get; set; }            // ID do filme avaliado
        public int Nota { get; set; }               // Nota da avaliação
        public string Comentario { get; set; }      // Comentário opcional
        public DateTime? DataAvaliacao { get; set; } // Data opcional (será DateTime.Now se não informado)
    }

    public class CriarAvaliacaoDTO
    {
        public int Nota { get; set; }
        public string Comentario { get; set; }
        public DateTime? DataAvaliacao { get; set; }

    }
}
