using ApiFilmes.BaseDados.Models;
using ApiFilmes.DTOs;
using ApiFilmes.Models;
using AutoMapper;

namespace ApiFilmes.Services.Parsers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // Filme
            CreateMap<FilmeDTO, Filme>();
            CreateMap<Filme, FilmeDTO>();

            // Genero
            CreateMap<GeneroDTO, Genero>();
            CreateMap<Genero, GeneroDTO>();

            // Diretor
            CreateMap<DiretorDTO, Diretor>();
            CreateMap<Diretor, DiretorDTO>();

            // Ator
            CreateMap<AtorDTO, Ator>();
            CreateMap<Ator, AtorDTO>();

            // Avaliacao
            CreateMap<AvaliacaoDTO, Avaliacao>();
            CreateMap<Avaliacao, AvaliacaoDTO>();
        }
    }
}