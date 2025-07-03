using ApiFilmes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ApiFilmes.Services
{
    public interface IGeneroService
    {
        Task<IEnumerable<GeneroDTO>> BuscarTodosAsync();
        Task<GeneroDTO> BuscarPorIdAsync(int id);
        Task<GeneroDTO> AdicionarAsync(GeneroDTO dto);
        Task AtualizarAsync(int id, GeneroDTO dto);
        Task RemoverAsync(int id);
    }
}
