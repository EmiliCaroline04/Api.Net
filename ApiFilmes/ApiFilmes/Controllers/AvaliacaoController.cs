using ApiFilmes.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class AvaliacaoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AvaliacaoDTO dto)
            => CreatedAtAction(nameof(GetById), new { id = 0 }, dto);

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AvaliacaoDTO dto)
            => NoContent();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => NoContent();
    }
}
