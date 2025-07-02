using ApiFilmes.DTOs;
using ApiFilmes.Models;
using ApiFilmes.Services;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class AtorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AtorService _atorService;

    public AtorController(IMapper mapper, AtorService atorService)
    {
        _mapper = mapper;
        _atorService = atorService;
    }


    [Produces("application/json", "application/xml")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var atores = await _atorService.BuscarTodosAsync(); // O serviço já retorna DTOs
        return Ok(atores);
    }

    [Produces("application/json", "application/xml")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var atorDto = await _atorService.BuscarPorIdAsync(id);
        if (atorDto == null)
            return NotFound();

        return Ok(atorDto);
    }

    [Produces("application/json", "application/xml")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AtorDTO dto)
    {
        var atorCriado = await _atorService.AdicionarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = atorCriado.Id }, atorCriado);
    }


    [Produces("application/json", "application/xml")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AtorDTO dto)
    {
        await _atorService.AtualizarAsync(id, dto);
        return NoContent();
    }


    [Produces("application/json", "application/xml")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound, "application/xml")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _atorService.RemoverAsync(id);
            return NoContent();
        }
        catch (NotFoundException) 
        {
            return NotFound();
        }
    }

}



