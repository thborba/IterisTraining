using CatalogoVideos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO
{
    public class CategoriaResponse
    {

        public CategoriaResponse(Categoria categoria)
        {
            Id = categoria.Id;
            Nome = categoria.Nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
