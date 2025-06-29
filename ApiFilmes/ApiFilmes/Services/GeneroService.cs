using ApiFilmes.Database.Models;
using ApiFilmes.DTOs;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public GeneroService(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GeneroDTO>> BuscarTodosAsync()
        {
            var generos = await _context.Generos.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<GeneroDTO>>(generos);
        }

        public async Task<GeneroDTO> BuscarPorIdAsync(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
                throw new NotFoundException("Gênero não encontrado.");

            return _mapper.Map<GeneroDTO>(genero);
        }

        public async Task<GeneroDTO> AdicionarAsync(GeneroDTO dto)
        {
            var genero = _mapper.Map<Models.Genero>(dto);
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();
            return _mapper.Map<GeneroDTO>(genero);
        }

        public async Task AtualizarAsync(int id, GeneroDTO dto)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
                throw new NotFoundException("Gênero não encontrado.");

            _mapper.Map(dto, genero);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
                throw new NotFoundException("Gênero não encontrado.");

            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();
        }
    }
}
