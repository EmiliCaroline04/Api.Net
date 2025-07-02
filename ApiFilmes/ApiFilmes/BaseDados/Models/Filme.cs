using ApiFilmes.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFilmes.BaseDados.Models
{

    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [Column("ano_lancamento")]
        public int? AnoLancamento { get; set; }

        [Column("duracao_min")]
        public int? DuracaoMin { get; set; }

        [Column("classificacao_etaria")]
        public string ClassificacaoEtaria { get; set; }
        public string Sinopse { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public int DiretorId { get; set; }
        public Diretor Diretor { get; set; }

        public List<Avaliacao> Avaliacoes { get; set; }
    }
}
