using ApiCliente.Database.Models;
using ApiCliente.Services.DTOs;
using ApiCliente.Services.Validations;
using ApiClientes.Controllers;
using ApiClientes.Services.Parsers;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiClientes.Services
{
    public class ClientesService
    {

        private readonly ClientesContext _dbcontext;

        public ClientesService(ClientesContext dbcontext)
        {

            _dbcontext = dbcontext;

        }

        public ClienteDTO Criar(CriarClienteDTO dto)
        {
            ClienteValidation.ValidouCriarCliente(dto);

            TbCliente novoCliente =
                ClienteParser.ToTbCliente(dto);

            _dbcontext.TbClientes.Add(novoCliente);
            _dbcontext.SaveChanges();
            return ClienteParser.ToClienteDTO(novoCliente);

        }

        internal object Atualizar(int id, AtualizarClienteDTO body)
        {
            throw new NotImplementedException();
        }

        internal object AtualizarParcial(int id, AtualizarClienteDTO body)
        {
            throw new NotImplementedException();
        }

        internal void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        internal object ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        internal object ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}