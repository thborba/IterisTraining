using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.Entity
{
    public class VideoCategoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VideoId { get; set; }
        [Required]
        public int CategoriaId { get; set; }

        public virtual Video Video { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
