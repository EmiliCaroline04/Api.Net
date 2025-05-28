using ApiCliente.Database.Models;
using ApiClientes.Services.DTOs;
using System;

namespace ApiClientes.Services.Parsers
{
    public static class EnderecoParser
    {
        public static TbEndereco ToTbEndereco(CriarEnderecoDTO dto)
        {
            return new TbEndereco
            {
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Cep = dto.Cep,
                Complemento = dto.Complemento,
                Status = dto.Status
            };
        }

        internal static EnderecoDTO ToEnderecoDTO(TbEndereco endereco)
        {
            throw new NotImplementedException();
        }

        internal static TbEndereco ToTbEndereco(CriaEnderecoDTO dto)
        {
            throw new NotImplementedException();
        }
    }

    internal class CriaEnderecoDTO
    {
    }

    public class CriarEnderecoDTO
    {
        public string Logradouro { get; internal set; }
        public string Numero { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public string Uf { get; internal set; }
        public int Cep { get; internal set; }
        public string Complemento { get; internal set; }
        public int Status { get; internal set; }
    }
}

    //    public static EnderecosDTO ToEnderecoDTO(TbEndereco endereco)
    //    {
    //        return new EnderecosDTO
    //        {
    //            IdCliente = endereco.Clienteid,
    //            Id = endereco.Id,
    //            Logradouro = endereco.Logradouro,
    //            Numero = endereco.Numero,
    //            Bairro = endereco.Bairro,
    //            Cidade = endereco.Cidade,
    //            Uf = endereco.Uf,
    //            Cep = endereco.Cep,
    //            Complemento = endereco.Complemento,
    //            Status = endereco.Status
    //        };
    //    }
    //}

//public class EnderecosDTO
//{
//    public int IdCliente { get; internal set; }
//    public int Id { get; internal set; }
//    public int Status { get; internal set; }
//    public string Logradouro { get; internal set; }
//    public string Numero { get; internal set; }
//    public string Bairro { get; internal set; }
//    public string Cidade { get; internal set; }
//    public string Uf { get; internal set; }
//    public int Cep { get; internal set; }
//    public string Complemento { get; internal set; }
//}
//}
