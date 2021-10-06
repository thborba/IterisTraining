
using CatalogoVideos.Domain.DTO;
using CatalogoVideos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsaveisController : ControllerBase
    {

		private readonly ResponsaveisService _responsaveisService;

		public ResponsaveisController(ResponsaveisService responsaveisService)
		{
			_responsaveisService = responsaveisService;
		}


		[HttpPost("CadastrarNovo")]
		public IActionResult CadastrarNovo([FromBody] ResponsavelCreateRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _responsaveisService.CadastrarNovo(model);
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


		[HttpGet("{id}/Pesquisar")]
		public IActionResult PesquisarPorId(int id)
		{
			var retorno = _responsaveisService.PesquisarPorId(id);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return NotFound(retorno);
			}
		}
	}
}
