using ApiFilmes.DTOs;
using ApiFilmes.BaseDados.Models; // Supondo que Diretor está aqui
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiFilmes.Database.Models;
using ApiFilmes.Models;
using Microsoft.AspNetCore.Http;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiretorController : ControllerBase
    {
        private readonly FilmesContext _context;
        private readonly IMapper _mapper;

        public DiretorController(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiretorDTO>>> GetAll()
        {
            var diretores = await _context.Diretores.ToListAsync();
            var diretoresDto = _mapper.Map<List<DiretorDTO>>(diretores);
            return Ok(diretoresDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DiretorDTO>> GetById(int id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
                return NotFound();

            var diretorDto = _mapper.Map<DiretorDTO>(diretor);
            return Ok(diretorDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPost]
        public async Task<ActionResult<DiretorDTO>> Create([FromBody] DiretorDTO dto)
        {
            var diretor = _mapper.Map<Diretor>(dto);
            _context.Diretores.Add(diretor);
            await _context.SaveChangesAsync();

            var novoDto = _mapper.Map<DiretorDTO>(diretor);
            return CreatedAtAction(nameof(GetById), new { id = diretor.Id }, novoDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
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

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
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
