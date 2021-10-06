using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CostumersController : ControllerBase
	{
		private readonly CustomersService _service;

		public CostumersController(CustomersService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int index, int qtd)
		{
			var retorno = await _service.Pesquisar(index, qtd);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return BadRequest(retorno);
			}
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var retorno = await _service.PesquisaPorId(id);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return NotFound(retorno);
			}
		}



		[HttpPost]
		// FromBody para indicar de o corpo da requisição deve ser mapeado para o modelo
		public async Task<IActionResult> Post([FromBody] CustomerCreateRequest postModel)
		{
			//Validação modelo de entrada
			if (ModelState.IsValid)
			{
				var retorno = await _service.Cadastrar(postModel);
				if (!retorno.Sucesso)
					return BadRequest(retorno);
				else
					return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}
	}
}
