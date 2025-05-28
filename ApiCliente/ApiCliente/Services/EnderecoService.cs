using ApiCliente.Database.Models;
using ApiClientes.Controllers;
using ApiClientes.Controllers.ApiClientes.Controllers;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Parsers;
using System.Collections.Generic;
using System.Linq;


namespace ApiClientes.Services
{
    public class EnderecosService
    {
        private readonly ClientesContext _dbcontext;

        public EnderecosService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<EnderecoDTO> ListarEnderecos(int id)
        {
            List<EnderecoDTO> response = new();
            var enderecos = _dbcontext.TbEnderecos.Where(e => e.Clienteid == id).ToList();
            foreach (var endereco in enderecos)
            {
                response.Add(EnderecoParser.ToEndereco(endereco));
            }
            return response;
        }
        // Adiciona um novo endereço ao cliente
        public EnderecoDTO Adicionar(int idCliente, CriarEnderecoDTO dto)
        {

            TbEndereco novoEndereco = EnderecoParser.ToTbEnderecoDTO(dto);
            // Exemplo de validação antes de salvar
            if (dto.uf.Length > 2)
                throw new BadRequestException("O campo UF deve ter no máximo 2 caracteres.");
            var cliente = _dbcontext.TbClientes.Find(idCliente);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado.");

            //var novoEnd = new TbEndereco
            //{
            //    Clienteid = idCliente,
            //    Cidade = dto.cidade,
            //    Bairro = dto.bairro,
            //    Uf = dto.uf,
            //    Complemento = dto.complemento,
            //    Logradouro = dto.logradouro,
            //    Numero = dto.numero,
            //    Status = dto.status,
            //    Cep = dto.cep
            //};

            novoEndereco.Clienteid = cliente.Id;

            _dbcontext.TbEnderecos.Add(novoEndereco);
            _dbcontext.SaveChanges();

            return new EnderecoDTO
            {
                id = novoEndereco.Id,
                idcliente = novoEndereco.Clienteid,
                cidade = novoEndereco.Cidade,
                bairro = novoEndereco.Bairro,
                uf = novoEndereco.Uf,
                complemento = novoEndereco.Complemento,
                logradouro = novoEndereco.Logradouro,
                numero = novoEndereco.Numero,
                status = novoEndereco.Status,
                cep = novoEndereco.Cep
            };
        }

        public EnderecoDTO BuscarEnderecoDeCliente(int idCliente, int idEndereco)
        {
            var endereco = _dbcontext.TbEnderecos
                .FirstOrDefault(e => e.Clienteid == idCliente && e.Id == idEndereco);

            if (endereco == null)
                throw new NotFoundException("Endereço não encontrado.");

            return new EnderecoDTO
            {
                id = endereco.Id,
                idcliente = endereco.Clienteid,
                cidade = endereco.Cidade,
                bairro = endereco.Bairro,
                uf = endereco.Uf,
                complemento = endereco.Complemento,
                logradouro = endereco.Logradouro,
                numero = endereco.Numero,
                status = endereco.Status,
                cep = endereco.Cep
            };
        }

        public void DeletarEnderecoDeCliente(int idCliente, int idEndereco)
        {
            var endereco = _dbcontext.TbEnderecos
                .FirstOrDefault(e => e.Clienteid == idCliente && e.Id == idEndereco);

            if (endereco == null)
                throw new NotFoundException("Endereço não encontrado.");

            _dbcontext.TbEnderecos.Remove(endereco);
            _dbcontext.SaveChanges();
        }
    }
}
