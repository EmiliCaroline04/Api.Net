using ApiFilmes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services.Entidades
{
    public interface IDiretorService
    {
        Task<IEnumerable<DiretorDTO>> BuscarTodosAsync();
        Task<DiretorDTO> BuscarPorIdAsync(int id);
        Task<DiretorDTO> AdicionarAsync(DiretorDTO dto);
        Task AtualizarAsync(int id, DiretorDTO dto);
        Task RemoverAsync(int id);
    }
}