using ApiCliente.Services.DTOs;
using ApiCliente.Services.Exceptions;
using ApiClientes.Controllers.ApiClientes.Controllers;
using ApiClientes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _service;
        public ClientesController(ClientesService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ClienteDTO> Adicionar([FromBody] CriarClienteDTO body)
        {
            try
            {

                var Response = _service.Criar(body);
                return Ok(Response); //200
            }
            catch (BadRequestExceptions B)
            {
                return BadRequest(B.Message);//400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message);//500
            }

        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> ObterPorId(int id)
        {
            try
            {
                var cliente = _service.ObterPorId(id);
                return Ok(cliente); //200
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message); //404
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); //500
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] AtualizarClienteDTO body)
        {
            try
            {
                var cliente = _service.Atualizar(id, body);
                return Ok(cliente); //200
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message); //404
            }
            catch (BadRequestExceptions b)
            {
                return BadRequest(b.Message); //400
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); //500
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<ClienteDTO> AtualizarParcial(int id, [FromBody] AtualizarClienteDTO body)
        {
            try
            {
                var cliente = _service.AtualizarParcial(id, body);
                return Ok(cliente); //200
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message); //404
            }
            catch (BadRequestExceptions b)
            {
                return BadRequest(b.Message); //400
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); //500
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent(); //204
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message); //404
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); //500
            }
        }

    }

}
