using CatalogoVideos.Domain.DTO;
using CatalogoVideos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {

		private readonly VideosService _videosService;

		public VideosController(VideosService tarefasService)
		{
			_videosService = tarefasService;
		}


		[HttpGet]
		public IEnumerable<VideoResponse> ListarTodos()
		{
			return _videosService.ListarTodos();
		}

		[HttpGet("Pesquisar/{id}")]
		public IActionResult PesquisarPorId(int id)
		{
			var retorno = _videosService.PesquisarPorId(id);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return NotFound(retorno);
			}
		}


		[HttpPost("CadastrarNovo")]
		public IActionResult Criar([FromBody] VideoCreateRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _videosService.CadastrarNovo(model);
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

		[HttpPut("{id}/URL")]
		public IActionResult EditarURL(int id, [FromBody] VideoUpdateRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _videosService.EditarURL(id, model);
				if (!retorno.Sucesso)
					return BadRequest(retorno.Mensagem);
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}


	}
}
