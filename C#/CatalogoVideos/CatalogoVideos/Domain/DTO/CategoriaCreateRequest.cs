using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO.Categorias
{
    public class CategoriaCreateRequest
    {

        [Required]
        public string Nome { get; set; }
    }
}
