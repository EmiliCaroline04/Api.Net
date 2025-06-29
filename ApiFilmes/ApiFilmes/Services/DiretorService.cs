using ApiFilmes.Database.Models;
using ApiFilmes.DTOs;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services
{
    public class DiretorService : IDiretorService
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public DiretorService(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiretorDTO>> BuscarTodosAsync()
        {
            var diretores = await _context.Diretores.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<DiretorDTO>>(diretores);
        }

        public async Task<DiretorDTO> BuscarPorIdAsync(int id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                throw new NotFoundException("Diretor não encontrado.");

            return _mapper.Map<DiretorDTO>(diretor);
        }

        public async Task<DiretorDTO> AdicionarAsync(DiretorDTO dto)
        {
            var diretor = _mapper.Map<Models.Diretor>(dto);
            _context.Diretores.Add(diretor);
            await _context.SaveChangesAsync();
            return _mapper.Map<DiretorDTO>(diretor);
        }

        public async Task AtualizarAsync(int id, DiretorDTO dto)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                throw new NotFoundException("Diretor não encontrado.");

            _mapper.Map(dto, diretor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                throw new NotFoundException("Diretor não encontrado.");

            _context.Diretores.Remove(diretor);
            await _context.SaveChangesAsync();
        }
    }
}