using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO
{
    public class VideoUpdateRequest
    {
        [Required]
        public string URL { get; set; }
    }
}
