using ApiFilmes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services.Entidades
{
    public interface IAtorService
    {
        Task<IEnumerable<AtorDTO>> BuscarTodosAsync();
        Task<AtorDTO> BuscarPorIdAsync(int id);
        Task<AtorDTO> AdicionarAsync(AtorDTO dto);
        Task AtualizarAsync(int id, AtorDTO dto);
        Task RemoverAsync(int id);
    }
}