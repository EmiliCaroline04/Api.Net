using ApiFilmes.DTOs;
using ApiFilmes.BaseDados.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiFilmes.Services;
using ApiFilmes.Services.Entidades;
using ApiFilmes.Services.Exceptions;
using System;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IMapper mapper, IAvaliacaoService avaliacaoService)
        {
            _mapper = mapper;
            _avaliacaoService = avaliacaoService;
        }

        [ProducesResponseType(typeof(IEnumerable<AvaliacaoDTO>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoDTO>>> GetAll()
        {
            var avaliacoes = await _avaliacaoService.BuscarTodosAsync();
            var avaliacoesDto = _mapper.Map<List<AvaliacaoDTO>>(avaliacoes);
            return Ok(avaliacoesDto);
        }

        [ProducesResponseType(typeof(AvaliacaoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var avaliacao = await _avaliacaoService.BuscarPorIdAsync(id);
                return Ok(avaliacao);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                // Log do erro interno
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [ProducesResponseType(typeof(AvaliacaoDTO), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<AvaliacaoDTO>> Create([FromBody] AvaliacaoDTO dto)
        {
            var novoDto = await _avaliacaoService.AdicionarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novoDto.FilmeId }, novoDto);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AvaliacaoDTO dto)
        {
            var existente = await _avaliacaoService.BuscarPorIdAsync(id);
            if (existente == null)
                return NotFound();

            await _avaliacaoService.AtualizarAsync(id, dto);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existente = await _avaliacaoService.BuscarPorIdAsync(id);
            if (existente == null)
                return NotFound();

            await _avaliacaoService.RemoverAsync(id);
            return NoContent();
        }
    }
}
