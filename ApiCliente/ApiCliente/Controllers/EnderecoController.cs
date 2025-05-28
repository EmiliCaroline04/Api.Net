using ApiClientes.Services.DTOs;
using ApiClientes.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiClientes.Controllers.ApiClientes.Controllers;
using System;

namespace ApiClientes.Controllers
{
    [Route("api/Clientes/{id}/[controller]")]
    [ApiController]
    public class EnderecosController : Controller
    {
        private readonly EnderecosService _service;

        public EnderecosController(EnderecosService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<EnderecoDTO>> GetEndereco(int id)
        {
            try
            {
                var response = _service.ListarEnderecos(id);
                return Ok(response); // 200
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message); // 500
            }
        }

        // POST: api/clientes/enderecos
        [HttpPost]
        public ActionResult<EnderecoDTO> Adicionar(int id, [FromBody] CriarEnderecoDTO body)
        {
            try
            {
                var response = _service.Adicionar(id, body);
                return Ok(response);
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message);
            }
            catch (NotFoundException N)
            {
                return NotFound(N.Message);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        // GET: api/clientes/enderecos/{idEndereco}
        [HttpGet("{idEndereco}")]
        public ActionResult<EnderecoDTO> BuscarEnderecoDeCliente(int id, int idEndereco)
        {
            try
            {
                var response = _service.BuscarEnderecoDeCliente(id, idEndereco);
                return Ok(response);
            }
            catch (NotFoundException N)
            {
                return NotFound(N.Message);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        // DELETE: api/clientes/{idCliente}/enderecos/{idEndereco}
        [HttpDelete]
        public IActionResult DeletarEnderecoDeCliente(int id, int idEndereco)
        {
            try
            {
                _service.DeletarEnderecoDeCliente(id, idEndereco);
                return NoContent();
            }
            catch (NotFoundException N)
            {
                return NotFound(N.Message);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }


    }

    [Serializable]
    internal class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
