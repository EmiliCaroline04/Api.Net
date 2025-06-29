using ApiFilmes.Models;
using System.Collections.Generic;

namespace ApiFilmes.BaseDados.Models
{

    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? AnoLancamento { get; set; }
        public int? DuracaoMin { get; set; }
        public string ClassificacaoEtaria { get; set; }
        public string Sinopse { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public int DiretorId { get; set; }
        public Diretor Diretor { get; set; }

        public List<Avaliacao> Avaliacoes { get; set; } // precisa existir!
    }
}
