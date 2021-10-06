using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdotaAnimais.Domain.DTO
{
    public class AnimalUpdateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}
