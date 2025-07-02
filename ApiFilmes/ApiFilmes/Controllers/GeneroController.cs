using ApiFilmes.DTOs;
using ApiFilmes.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiFilmes.Services.Exceptions;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class GeneroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly GeneroService _service;

        public GeneroController(IMapper mapper, GeneroService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generos = await _service.BuscarTodosAsync();
            var dtoList = _mapper.Map<List<GeneroDTO>>(generos);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generoDto = await _service.BuscarPorIdAsync(id);
            if (generoDto == null)
                return NotFound();
            return Ok(generoDto);
        }

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
