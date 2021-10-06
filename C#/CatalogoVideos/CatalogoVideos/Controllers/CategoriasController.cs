using CatalogoVideos.Domain.DTO;
using CatalogoVideos.Domain.DTO.Categorias;
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
    public class CategoriasController : ControllerBase
    {

		private readonly CategoriasService _categoriasService;

		public CategoriasController(CategoriasService tarefasService)
		{
			_categoriasService = tarefasService;
		}


		[HttpGet]
		public IEnumerable<CategoriaResponse> ListarTodos()
		{
			return _categoriasService.ListarTodos();
		}


		[HttpPost("CadastrarNovo")]
		public IActionResult CadastrarNovo([FromBody] CategoriaCreateRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _categoriasService.CadastrarNovo(model);
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
	}
}
