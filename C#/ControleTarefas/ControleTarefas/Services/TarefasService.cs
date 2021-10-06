using ControleTarefas.DAL;
using ControleTarefas.Domain.DTO;
using ControleTarefas.Domain.Entity;
using ControleTarefas.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Services
{
	public class TarefasService
	{


		private readonly AppDbContext _dbContext;
		public TarefasService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ServiceResponse<Tarefa> CadastrarNovo(TarefaCreateRequest model)
		{
			Tarefa novaTarefa = new Tarefa()
			{
				Titulo = model.Titulo,
				Descricao = model.Descricao,
				Prioridade = model.Prioridade ?? 5,
				Concluido = false

			};

			_dbContext.Add(novaTarefa);
			_dbContext.SaveChanges();

			return new ServiceResponse<Tarefa>(novaTarefa);
		}

		public IEnumerable<TarefaResponse> ListarTodos()
		{

			List<Tarefa> retornoDoBanco = _dbContext.Tarefas.ToList();

			IEnumerable<TarefaResponse> lista = retornoDoBanco.Select(x => new TarefaResponse(x));

			return lista;
		}

		public ServiceResponse<TarefaResponse> PesquisarPorId(int id)
		{
			var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.Id == id);
			if (resultado == null)
				return new ServiceResponse<TarefaResponse>("Não encontrado!");
			else
				return new ServiceResponse<TarefaResponse>(new TarefaResponse(resultado));
		}

		public ServiceResponse<TarefaResponse> EditarStatus(int id, TarefaUpdateStatusRequest model)
		{ 
			Tarefa resultado = _dbContext.Tarefas.FirstOrDefault(x => x.Id == id);

			if (resultado == null)
				return new ServiceResponse<TarefaResponse>("Tarefa não encontrada!");

			resultado.Concluido = model.Concluido;
			_dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return new ServiceResponse<TarefaResponse>(new TarefaResponse(resultado));
		}

		public ServiceResponse<TarefaResponse> EditarPrioridade(int id, TarefaUpdatePrioridadeRequest model)
		{
			Tarefa resultado = _dbContext.Tarefas.FirstOrDefault(x => x.Id == id);

			if (resultado == null)
				return new ServiceResponse<TarefaResponse>("Tarefa não encontrada!");

			resultado.Prioridade = model.Prioridade;
			_dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return new ServiceResponse<TarefaResponse>(new TarefaResponse(resultado));
		}

		public ServiceResponse<bool> Deletar(int id)
		{
			var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.Id == id);

			if (resultado == null)
				return new ServiceResponse<bool>("Tarefa não encontrada!");

			_dbContext.Tarefas.Remove(resultado);
			_dbContext.SaveChanges();

			return new ServiceResponse<bool>(true);
		}
	}
}
