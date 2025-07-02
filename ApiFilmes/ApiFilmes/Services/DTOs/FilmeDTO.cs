namespace ApiFilmes.DTOs
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? AnoLancamento { get; set; }
        public int? DuracaoMin { get; set; }
        public string ClassificacaoEtaria { get; set; }
        public string Sinopse { get; set; }

        public int GeneroId { get; set; }
        public int DiretorId { get; set; }

    }


    public class CriarAlunoDTO
    {
        public string Titulo { get; set; }
        public int? AnoLancamento { get; set; }
        public int? DuracaoMin { get; set; }
        public string ClassificacaoEtaria { get; set; }
        public string Sinopse { get; set; }

    }
}
