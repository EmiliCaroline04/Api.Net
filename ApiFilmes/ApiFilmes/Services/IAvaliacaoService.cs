using ApiFilmes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<AvaliacaoDTO>> BuscarTodosAsync();
        Task<AvaliacaoDTO> BuscarPorIdAsync(int id);
        Task<AvaliacaoDTO> AdicionarAsync(AvaliacaoDTO dto);
        Task AtualizarAsync(int id, AvaliacaoDTO dto);
        Task RemoverAsync(int id);
    }
}
