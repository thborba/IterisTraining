using ControleTarefas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Domain.DTO
{
    public class TarefaResponse
    {

		public TarefaResponse(Tarefa tarefa)
		{
			Id = tarefa.Id;
			Titulo = tarefa.Titulo;
			Descricao = tarefa.Descricao;
			Concluido = tarefa.Concluido;
			Prioridade = tarefa.Prioridade;
		}

		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public bool Concluido { get; set; }
		public int Prioridade { get; set; }

	}
}
