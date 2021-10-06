using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.Entity
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ResponsavelId { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(255)]
        public string URL { get; set; }
        public int? Idade { get; set; }


        public virtual Responsavel Responsavel { get;set;}
        public virtual ICollection<VideoCategoria> VideoCategorias { get; set; }
    }
}
