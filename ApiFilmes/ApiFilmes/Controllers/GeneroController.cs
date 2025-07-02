using ApiFilmes.DTOs;
using ApiFilmes.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiFilmes.Services.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly GeneroService _service;

        public GeneroController(IMapper mapper, GeneroService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generos = await _service.BuscarTodosAsync();
            var dtoList = _mapper.Map<List<GeneroDTO>>(generos);
            return Ok(dtoList);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generoDto = await _service.BuscarPorIdAsync(id);
            if (generoDto == null)
                return NotFound();
            return Ok(generoDto);
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GeneroDTO dto)
        {
            try
            {
                var generoSalvo = await _service.AdicionarAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = generoSalvo.Id }, generoSalvo);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GeneroDTO dto)
        {
            try
            {
                await _service.AtualizarAsync(id, dto);
                return NoContent();
            }
            catch (NotFoundException)
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
                await _service.RemoverAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
