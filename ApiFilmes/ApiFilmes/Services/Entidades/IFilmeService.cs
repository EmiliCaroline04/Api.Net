using ApiFilmes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFilmes.Services.Entidades
{
    public interface IFilmeService
    {
        
        Task<IEnumerable<FilmeDTO>> BuscarTodosAsync();
        Task<FilmeDTO> BuscarPorIdAsync(int id);
        Task<FilmeDTO> AdicionarAsync(FilmeDTO dto);
        Task AtualizarAsync(int id, FilmeDTO dto);
        Task RemoverAsync(int id);
    }
}