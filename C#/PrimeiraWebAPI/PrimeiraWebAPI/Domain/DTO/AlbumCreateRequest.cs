using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class AlbumCreateRequest
    {

		[Required(AllowEmptyStrings = false)]
		public string Nome { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "O Artista é obrigatório!")]
		public string Artista { get; set; }
		[Required]
		public int? AnoLancamento { get; set; }
	}
}
