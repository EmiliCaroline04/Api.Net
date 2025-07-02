using ApiFilmes.DTOs;
using ApiFilmes.BaseDados.Models; // Supondo que Diretor está aqui
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiFilmes.Database.Models;
using ApiFilmes.Models;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class DiretorController : ControllerBase
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public DiretorController(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiretorDTO>>> GetAll()
        {
            var diretores = await _context.Diretores.ToListAsync();
            var diretoresDto = _mapper.Map<List<DiretorDTO>>(diretores);
            return Ok(diretoresDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiretorDTO>> GetById(int id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                return NotFound();

            var diretorDto = _mapper.Map<DiretorDTO>(diretor);
            return Ok(diretorDto);
        }

        [HttpPost]
        public async Task<ActionResult<DiretorDTO>> Create([FromBody] DiretorDTO dto)
        {
            var diretor = _mapper.Map<Diretor>(dto);
            _context.Diretores.Add(diretor);
            await _context.SaveChangesAsync();

            var novoDto = _mapper.Map<DiretorDTO>(diretor);
            return CreatedAtAction(nameof(GetById), new { id = diretor.Id }, novoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DiretorDTO dto)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                return NotFound();

            _mapper.Map(dto, diretor); // Atualiza os dados da entidade
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                return NotFound();

            _context.Diretores.Remove(diretor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
