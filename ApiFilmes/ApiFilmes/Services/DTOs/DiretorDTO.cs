using System;

namespace ApiFilmes.DTOs
{
    public class DiretorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }

    public class CriarDiretorDTO
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }

    }
