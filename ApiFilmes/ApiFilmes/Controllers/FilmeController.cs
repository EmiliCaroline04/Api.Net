using ApiFilmes.DTOs;
using ApiFilmes.BaseDados.Models; 
using ApiFilmes.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiFilmes.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using ApiFilmes.Services.Entidades;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmeService _filmeService;

        public FilmeController(IMapper mapper, FilmeService filmeService)
        {
            _mapper = mapper;
            _filmeService = filmeService;
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filmes = await _filmeService.BuscarTodosAsync();

            // Mapear lista de entidades para DTOs
            var dtoList = _mapper.Map<List<FilmeDTO>>(filmes);

            return Ok(dtoList);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filme = await _filmeService.BuscarPorIdAsync(id);

            if (filme == null)
                return NotFound();

            var dto = _mapper.Map<FilmeDTO>(filme);

            return Ok(dto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FilmeDTO dto)
        {
            // Mapear DTO para entidade
            var filme = _mapper.Map<Filme>(dto);

            // Adicionar no banco
            var novoFilme = await _filmeService.AdicionarAsync(dto);

            // Mapear novamente para DTO se quiser retornar
            var novoFilmeDto = _mapper.Map<FilmeDTO>(novoFilme);

            return CreatedAtAction(nameof(GetById), new { id = novoFilmeDto.Id }, novoFilmeDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FilmeDTO dto)
        {
            try
            {
                await _filmeService.AtualizarAsync(id, dto);
                return NoContent();
            }
            catch (NotFoundException) // Se seu serviço lançar essa exceção
            {
                return NotFound();
            }
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _filmeService.RemoverAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
