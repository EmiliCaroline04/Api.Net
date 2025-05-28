using ApiCliente.Database.Models;
using ApiCliente.Services.Validations;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiClientes.Services
{
    public class EnderecoService
    {
        private readonly ClientesContext _dbcontext;

        public EnderecoService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public EnderecoDTO Criar(int clienteId, CriarEnderecoDTO dto)
        {
            EnderecoValidation.ValidarCriarEndereco(dto);

            TbEndereco novoEndereco = EnderecoParser.ToTbEndereco(dto);
            novoEndereco.Clienteid = clienteId;

            _dbcontext.TbEnderecos.Add(novoEndereco);
            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(novoEndereco);
        }

        public IEnumerable<EnderecoDTO> BuscarTodos(int clienteId)
        {
            return _dbcontext.TbEnderecos
                .Where(e => e.Clienteid == clienteId)
                .Select(e => EnderecoParser.ToEnderecoDTO(e))
                .ToList();
        }

        public EnderecoDTO BuscarPorId(int clienteId, int id)
        {
            var endereco = _dbcontext.TbEnderecos
                .FirstOrDefault(e => e.Clienteid == clienteId && e.Id == id);

            if (endereco == null)
            {
                throw new Exception("Endereço não encontrado");
            }

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO Atualizar(int clienteId, int id, DTOs.CriarEnderecoDTO body)
        {
            var endereco = _dbcontext.TbEnderecos.Find(id);

            if (endereco == null || endereco.Clienteid != clienteId)
            {
                throw new Exception("Endereço não encontrado");
            }

            endereco.Cep = body.Cep;
            endereco.Logradouro = body.Logradouro;
            endereco.Numero = body.Numero;
            endereco.Complemento = body.Complemento;
            endereco.Bairro = body.Bairro;
            endereco.Cidade = body.Cidade;
            endereco.Uf = body.Uf;

            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public void Deletar(int clienteId, int id)
        {
            var endereco = _dbcontext.TbEnderecos.Find(id);

            if (endereco == null || endereco.Clienteid != clienteId)
            {
                throw new Exception("Endereço não encontrado");
            }

            _dbcontext.TbEnderecos.Remove(endereco);
            _dbcontext.SaveChanges();
        }

        internal object Criar(int clienteId, Controllers.CriarEnderecoDTO body)
        {
            throw new NotImplementedException();
        }

        internal object Atualizar(int clienteId, int id, Controllers.CriarEnderecoDTO body)
        {
            throw new NotImplementedException();
        }

        internal object Criar(int clienteId, DTOs.CriarEnderecoDTO body)
        {
            throw new NotImplementedException();
        }
    }

  
}