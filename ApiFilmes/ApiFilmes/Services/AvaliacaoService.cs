using ApiFilmes.BaseDados.Models;
using ApiFilmes.Database.Models;
using ApiFilmes.DTOs;
using ApiFilmes.Services.Entidades;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ApiFilmes.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public AvaliacaoService(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvaliacaoDTO>> BuscarTodosAsync()
        {
            var avaliacoes = await _context.Avaliacoes.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<AvaliacaoDTO>>(avaliacoes);
        }

        public async Task<AvaliacaoDTO> BuscarPorIdAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                throw new NotFoundException("Avaliação não encontrada.");

            return _mapper.Map<AvaliacaoDTO>(avaliacao);
        }

        public async Task<AvaliacaoDTO> AdicionarAsync(AvaliacaoDTO dto)
        {
            var avaliacao = _mapper.Map<Avaliacao>(dto);
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoDTO>(avaliacao);
        }

        public async Task AtualizarAsync(int id, AvaliacaoDTO dto)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                throw new NotFoundException("Avaliação não encontrada.");

            _mapper.Map(dto, avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                throw new NotFoundException("Avaliação não encontrada.");

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
        }
    }
}
