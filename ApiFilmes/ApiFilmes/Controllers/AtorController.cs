using ApiFilmes.DTOs;
using ApiFilmes.Models;
using ApiFilmes.Services;
using ApiFilmes.Services.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
[Produces("application/json", "application/xml")]
public class AtorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AtorService _atorService;

    public AtorController(IMapper mapper, AtorService atorService)
    {
        _mapper = mapper;
        _atorService = atorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var atores = await _atorService.BuscarTodosAsync(); // O serviço já retorna DTOs
        return Ok(atores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var atorDto = await _atorService.BuscarPorIdAsync(id);
        if (atorDto == null)
            return NotFound();

        return Ok(atorDto);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AtorDTO dto)
    {
        var atorCriado = await _atorService.AdicionarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = atorCriado.Id }, atorCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AtorDTO dto)
    {
        await _atorService.AtualizarAsync(id, dto);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _atorService.RemoverAsync(id);
            return NoContent();
        }
        catch (NotFoundException) // Se seu serviço lançar essa exceção
        {
            return NotFound();
        }
    }

}
