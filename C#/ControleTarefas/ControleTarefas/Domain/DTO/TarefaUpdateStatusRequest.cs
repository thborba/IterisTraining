using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Domain.DTO
{
    public class TarefaUpdateStatusRequest
    {
        [Required]
        public bool Concluido { get; set; }
    }
}
