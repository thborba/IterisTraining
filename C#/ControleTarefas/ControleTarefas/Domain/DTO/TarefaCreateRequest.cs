using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Domain.DTO
{
    public class TarefaCreateRequest
    {

		[Required]
		public string Titulo { get; set; }
		public string Descricao { get; set; }

		[Range(1,5)]
		public int? Prioridade { get; set; }

	}
}
