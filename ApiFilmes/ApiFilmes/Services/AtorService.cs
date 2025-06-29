using ApiFilmes.Database.Models;
using ApiFilmes.DTOs;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ApiFilmes.Services
{
    public class AtorService : IAtorService
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public AtorService(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AtorDTO>> BuscarTodosAsync()
        {
            var atores = await _context.Atores.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<AtorDTO>>(atores);
        }

        public async Task<AtorDTO> BuscarPorIdAsync(int id)
        {
            var ator = await _context.Atores.FindAsync(id);
            if (ator == null)
                throw new NotFoundException("Ator não encontrado.");

            return _mapper.Map<AtorDTO>(ator);
        }

        public async Task<AtorDTO> AdicionarAsync(AtorDTO dto)
        {
            var ator = _mapper.Map<Models.Ator>(dto);
            _context.Atores.Add(ator);
            await _context.SaveChangesAsync();
            return _mapper.Map<AtorDTO>(ator);
        }

        public async Task AtualizarAsync(int id, AtorDTO dto)
        {
            var ator = await _context.Atores.FindAsync(id);
            if (ator == null)
                throw new NotFoundException("Ator não encontrado.");

            _mapper.Map(dto, ator);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var ator = await _context.Atores.FindAsync(id);
            if (ator == null)
                throw new NotFoundException("Ator não encontrado.");

            _context.Atores.Remove(ator);
            await _context.SaveChangesAsync();
        }
    }

}
