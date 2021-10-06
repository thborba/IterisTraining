using CatalogoVideos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO
{
    public class ResponsavelResponse
    {

        public ResponsavelResponse(Responsavel responsavel)
        {
            Id = responsavel.Id;
            Nome = responsavel.Nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
