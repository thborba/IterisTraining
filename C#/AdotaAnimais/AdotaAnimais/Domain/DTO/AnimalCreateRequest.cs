using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdotaAnimais.Domain.DTO
{
    public class AnimalCreateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório!")]
        public string Nome { get; set; }
        [Required]
        public int? Idade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A idade é obrigatória!")]
        public string Especie { get; set; }
        public DateTime? DataNascimento { get; set; }
        [Required]
        //[Range(1, 5)]
        public int Fofura { get; set; }
        [Required]
        //[Range(1, 5)]
        public int Carinho { get; set; }

        [EmailAddress(ErrorMessage = "O email deve ser válido!")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}
