using System;

namespace ApiFilmes.DTOs
{
    public class AtorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }

    public class CriarAtorDTO
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

    }
}
