using ControleTarefas.Domain.DTO;
using ControleTarefas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private readonly TarefasService _tarefasService;

        public TarefasController(TarefasService tarefasService)
        {
            _tarefasService = tarefasService;
        }


		[HttpGet]
		public IEnumerable<TarefaResponse> ListarTodos()
		{
			return _tarefasService.ListarTodos();
		}

		[HttpGet("Pesquisar/{id}")]
		public IActionResult PesquisarPorId(int id)
		{
			var retorno = _tarefasService.PesquisarPorId(id);

			if (retorno.Sucesso)
			{
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return NotFound(retorno);
			}
		}

		
		[HttpPost("NovaTarefa")]
		public IActionResult Criar([FromBody] TarefaCreateRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _tarefasService.CadastrarNovo(model);
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

		[HttpPut("EditarStatus/{id}")]
		public IActionResult Put(int id, [FromBody] TarefaUpdateStatusRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _tarefasService.EditarStatus(id, model);
				if (!retorno.Sucesso)
					return BadRequest(retorno.Mensagem);
				return Ok(retorno.ObjetoRetorno);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}

		[HttpPut("EditarPrioridade/{id}")]
		public IActionResult Put(int id, [FromBody] TarefaUpdatePrioridadeRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _tarefasService.EditarPrioridade(id, model);
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
		public IActionResult Deletar(int id)
		{
			var retorno = _tarefasService.Deletar(id);
			if (!retorno.Sucesso)
				return BadRequest(retorno.Mensagem);
			return Ok();

		}

	}
}
