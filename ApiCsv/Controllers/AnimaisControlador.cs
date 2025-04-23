using ApiCsv.DataBase;
using ApiCsv.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ApiCsv.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // anotações ou aspectos 
    public class AnimaisController : ControllerBase // não precisa dar new já está registrado no builder controller
    {
        private readonly DBContext _dbContext; //(Atributo global privete)// readonly somente edição por dentro do objeto

        public AnimaisController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()

        {
            return Ok(_dbContext.Animals);
        }
        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {

            try
            {
                Animal animal =
                    _dbContext
                    .Animals.Find(a => a.Id == id);
                if (animal == null)
                    return NotFound(); // 404

                return Ok(animal); // 200

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); //400
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Animal animal =
                    _dbContext
                    .Animals.Find(a => a.Id == id);
                if (animal == null) 
                    return NotFound(); // 404
                _dbContext.Animals.Remove(animal);
                return NoContent(); // 200

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); //400
            }
            }
            [HttpPatch("AlterarNome")]
            public ActionResult<Animal> AlterarNome(
                [FromBody] Animal body)

            {
                if ((body == null) ||
                        (string.IsNullOrEmpty(body.Nome)))
                    return BadRequest();
                Animal animal =
                    _dbContext
                    .Animals.Find(a => a.Id == body.Id);

                if (animal == null)
                    return NotFound();
                animal.Nome = body.Nome;
                return Ok(animal);


            }
        [HttpPut("AtualizarAnimal")]
        public ActionResult<Animal> put(
         [FromBody] Animal novoAnimal)
        {
            try
            {
                Animal alterado = _dbContext.Animals.FirstOrDefault(a => a.Id == novoAnimal.Id);

                if (novoAnimal == null)
                    return NotFound();

                alterado.Nome = novoAnimal.Nome;
                alterado.Classification = novoAnimal.Classification;
                alterado.Origin = novoAnimal.Origin;
                alterado.Reproduction = novoAnimal.Reproduction;
                alterado.Feeding = novoAnimal.Feeding;
                return Ok(novoAnimal);
            }
            catch (SystemException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CadastrarNovoAnimal")]
        public ActionResult<Animal> post(
            [FromBody] Animal novoAnimal)
        {
            try
            {
                _dbContext.Animals.Add(novoAnimal);
                return CreatedAtAction(nameof(GetById), new { id = novoAnimal.Id }, novoAnimal);

            }
            catch
            (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }

    }   


    }
