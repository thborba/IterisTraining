using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Domain.Entity
{
	[Table("Tarefas")]
    public class Tarefa
    {

		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Titulo { get; set; }
		[StringLength(255)]
		public string Descricao { get; set; }
		[Required]
		public bool Concluido { get; set; }

		[Required]
		public int Prioridade { get; set; }

	}
}
