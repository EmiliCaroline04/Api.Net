using ApiFilmes.DTOs;
using ApiFilmes.BaseDados.Models; // Supondo que Avaliacao está aqui
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiFilmes.Database.Models;
using ApiFilmes.Services;
using Microsoft.AspNetCore.Http;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Produces("application/json", "application/xml")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly FilmesContext _context;
        private readonly AvaliacaoService _avaliacaoService;
        private readonly IMapper _mapper;

        public AvaliacaoController(FilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoDTO>>> GetAll()
        {
            var avaliacoes = await _context.Avaliacoes.ToListAsync();
            var avaliacoesDto = _mapper.Map<List<AvaliacaoDTO>>(avaliacoes);
            return Ok(avaliacoesDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var avaliacao = await _avaliacaoService.BuscarPorIdAsync(id);
            if (avaliacao == null)
                return NotFound();

            var dto = _mapper.Map<AvaliacaoDTO>(avaliacao);
            return Ok(dto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPost]
        public async Task<ActionResult<AvaliacaoDTO>> Create([FromBody] AvaliacaoDTO dto)
        {
            var avaliacao = _mapper.Map<Avaliacao>(dto);
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            var novoDto = _mapper.Map<AvaliacaoDTO>(avaliacao);
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, novoDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AvaliacaoDTO dto)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                return NotFound();

            _mapper.Map(dto, avaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                return NotFound();

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
