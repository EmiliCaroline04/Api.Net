using ApiClientes.Controllers;
using ApiClientes.Services;
using ApiClientes.Services.DTOs;
using FluentValidation;
using System;

namespace ApiCliente.Services.Validations
{
    public class EnderecoValidation
    {
        public static void ValidouCriarEndereco(
            CriarEnderecoDTO criarEnderecoDTO)
        {
            if (string.IsNullOrEmpty(criarEnderecoDTO.Cep))
                throw new BadResquestException(
                    "Cep é Obrigatorio");
            if (string.IsNullOrEmpty(criarEnderecoDTO.Logradouro))
                throw new BadResquestException(
                   "Logradouro é Obrigatorio");

            if (string.IsNullOrEmpty(criarEnderecoDTO.Numero))
                throw new BadResquestException(
                   "Numero é Obrigatorio");

            if (string.IsNullOrEmpty(criarEnderecoDTO.Bairro))
                throw new BadResquestException(
                   "Bairro é Obrigatorio");

            if (string.IsNullOrEmpty(criarEnderecoDTO.Cidade))
                throw new BadResquestException(
                   "Cidade é Obrigatorio");

            if (string.IsNullOrEmpty(criarEnderecoDTO.Uf))
                throw new BadResquestException(
                   "Uf é Obrigatorio");


        }

        internal static void ValidarCriarEndereco(CriaEnderecoDTO dto)
        {
            throw new NotImplementedException();
        }

        public class AbstractValidator<T>
        {
        }
    }

    internal class CriaEnderecoDTO
    {
    }
}
