using ApiCliente.Services.DTOs;
using Microsoft.AspNetCore.Http.Connections;
using System.Linq;

namespace ApiCliente.Services.Validations
{
    public class ClienteValidation
    {
        public static void ValidouCriarCliente(
            CriarClienteDTO criarClienteDTO)
        {
            if (string.IsNullOrEmpty(criarClienteDTO.Nome))
                throw new BadResquestException(
                    "Nome é Obrigatorio");
            if (string.IsNullOrEmpty(criarClienteDTO.Documento))
                throw new BadResquestException(
                   "Documento é Obrigatorio");

            if (!new[] { 0, 1, 2, 3, 99 }.Contains(
                criarClienteDTO.Tipodoc))
                throw new BadResquestException(
                    "Tipo de documento não suportado");

        }
    }
}
