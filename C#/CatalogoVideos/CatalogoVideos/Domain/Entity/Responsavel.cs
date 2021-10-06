using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.Entity
{
    public class Responsavel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
