using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO
{
    public class ResponsavelCreateRequest
    {
        [Required]
        public string Nome { get; set; }
    }
}
