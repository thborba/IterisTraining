using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Domain.DTO
{
    public class TarefaUpdatePrioridadeRequest
    {
        [Required]
        [Range(1, 5)]
        public int Prioridade { get; set; }
    }
}
