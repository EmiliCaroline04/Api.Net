using System;
using ApiCliente.Database.Models;
using ApiClientes.Services.DTOs;

namespace ApiClientes.Services.Parsers
{
    public class EnderecoParser
    {
        public static TbEndereco ToTbEnderecoDTO(CriarEnderecoDTO dto)
        {
            TbEndereco novoEndereco = new();

            novoEndereco.Logradouro = dto.logradouro;
            novoEndereco.Numero = dto.numero;
            novoEndereco.Bairro = dto.bairro;
            novoEndereco.Cidade = dto.cidade;
            novoEndereco.Uf = dto.uf;
            novoEndereco.Cep = dto.cep;
            novoEndereco.Complemento = dto.complemento;
            novoEndereco.Status = dto.status;
            return novoEndereco;

        }

        public static EnderecoDTO ToEndereco(TbEndereco endereco)
        {
            EnderecoDTO response = new();
            response.idcliente = endereco.Clienteid;
            response.id = endereco.Id;
            response.logradouro = endereco.Logradouro;
            response.numero = endereco.Numero;
            response.bairro = endereco.Bairro;
            response.cidade = endereco.Cidade;
            response.uf = endereco.Uf;
            response.cep = endereco.Cep;
            response.complemento = endereco.Complemento;
            response.status = endereco.Status;
            return response;
        }

        internal static object ToDTO(TbEndereco e)
        {
            throw new NotImplementedException();
        }
    }
}
