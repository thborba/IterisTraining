using AdotaAnimais.Domain.DTO;
using AdotaAnimais.Domain.Entity;
using AdotaAnimais.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdotaAnimais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
		private readonly AnimalService animalService;

		public AnimalController(AnimalService animalService)
		{
			this.animalService = animalService;
		}

		[HttpGet("ListaAnimais")]
		public IEnumerable<Animal> Get()
		{
			return animalService.ListarTodos();
		}
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(int id)
		{
			var retorno = animalService.PesquisarPorId(id);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return NotFound(retorno.Mensagem);
			}
		}
		[HttpGet("GetByNome/{nomeParam}")]
		public IActionResult GetByNome(string nomeParam) 
		{
			var retorno = animalService.PesquisarPorNome(nomeParam);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return NotFound(retorno.Mensagem);
			}
		}

		[HttpPost("Cadastrar")]
		public IActionResult CadastrarAnimal([FromBody] AnimalCreateRequest model)
		{
			//Validação modelo de entrada
			if (ModelState.IsValid)
			{
				var retorno = animalService.CadastrarNovo(model);
				if (!retorno.Sucesso)
					return BadRequest(retorno.Mensagem);
				else
					return Ok(retorno);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}

		[HttpPut("Editar/{id}")]
		public IActionResult EditarAnimal(int id, [FromBody] AnimalUpdateRequest putModel)
		{
			if (ModelState.IsValid)
			{
				var retorno = animalService.Editar(id, putModel);
				if (!retorno.Sucesso)
					return BadRequest(retorno.Mensagem);
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}

		[HttpDelete("Deletar/{id}")]
		public IActionResult Delete(int id)
		{
			var retorno = animalService.Deletar(id);
			if (!retorno.Sucesso)
				return BadRequest(retorno.Mensagem);
			return Ok();

		}
	}
}
