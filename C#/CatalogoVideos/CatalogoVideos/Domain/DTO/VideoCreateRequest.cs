using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO
{
    public class VideoCreateRequest
    {
        [Required]
        public int ReponsavelId { get; set; }
        [Required]
        public int[] CategoriaIds { get; set; }
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string URL { get; set; }

        public int? Idade { get; set; }


    }
}
