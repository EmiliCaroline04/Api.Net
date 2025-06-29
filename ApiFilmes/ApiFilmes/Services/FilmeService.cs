using ApiFilmes.BaseDados.Models;
using ApiFilmes.Database.Models;
using ApiFilmes.DTOs;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public FilmeService(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FilmeDTO>> BuscarTodosAsync()
        {
            var filmes = await _context.Filmes.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<FilmeDTO>>(filmes);
        }

        public async Task<FilmeDTO> BuscarPorIdAsync(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                throw new NotFoundException("Filme não encontrado.");

            return _mapper.Map<FilmeDTO>(filme);
        }

        public async Task<FilmeDTO> AdicionarAsync(FilmeDTO dto)
        {
            var filme = _mapper.Map<Filme>(dto);
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return _mapper.Map<FilmeDTO>(filme);
        }

        public async Task AtualizarAsync(int id, FilmeDTO dto)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                throw new NotFoundException("Filme não encontrado.");

            _mapper.Map(dto, filme);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                throw new NotFoundException("Filme não encontrado.");

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }
    }
}