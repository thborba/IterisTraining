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
	public class PurchasesController : ControllerBase
	{
		private readonly PurchasesService _service;

		public PurchasesController(PurchasesService service)
		{
			_service = service;
		}

		[HttpPost]
		// FromBody para indicar de o corpo da requisição deve ser mapeado para o modelo
		public async Task<IActionResult> Post([FromBody] PurchaseCreateRequest postModel)
		{
			//Validação modelo de entrada
			if (ModelState.IsValid)
			{
				var retornoCriacao = await _service.Cadastrar(postModel);
				if (retornoCriacao.Sucesso)
				{
					return Ok(retornoCriacao.ObjetoRetorno);
				}
				else
				{
					return BadRequest(retornoCriacao);
				}
			}
			else
			{
				return BadRequest(ModelState);
			}

		}
	}
}
