using ApiFilmes.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class FilmeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // var filmes = await _filmeService.BuscarTodosAsync();
            return Ok(/*filmes*/);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // var filme = await _filmeService.BuscarPorIdAsync(id);
            // if (filme == null) return NotFound();
            return Ok(/*filme*/);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FilmeDTO dto)
        {
            // var novoFilme = await _filmeService.AdicionarAsync(dto);
            // return CreatedAtAction(nameof(GetById), new { id = novoFilme.Id }, novoFilme);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FilmeDTO dto)
        {
            // await _filmeService.AtualizarAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // await _filmeService.RemoverAsync(id);
            return NoContent();
        }
    }
}
   
   

