using CatalogoVideos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Domain.DTO
{
    public class VideoResponse
    {

        public VideoResponse()
        {
            ListaCategorias = new List<CategoriaResponse>();
        }

        public VideoResponse(Video video)
        {
            Id = video.Id;
            ResponsavelId = video.ResponsavelId;
            Titulo = video.Titulo;
            URL = video.URL;
            Idade = video.Idade;
        }

        public VideoResponse(Video video, List<CategoriaResponse> listaCategorias)
        {
            Id = video.Id;
            ResponsavelId = video.ResponsavelId;
            Titulo = video.Titulo;
            URL = video.URL;
            Idade = video.Idade;
            ListaCategorias = listaCategorias;
        }

        public int Id { get; set; }
        public int ResponsavelId { get; set; }
        public string Titulo { get; set; }
        public string URL { get; set; }
        public int? Idade { get; set; }

        public List<CategoriaResponse> ListaCategorias { get; set; }
    }

}
