using CatalogoVideos.DAL;
using CatalogoVideos.Domain.DTO;
using CatalogoVideos.Domain.Entity;
using CatalogoVideos.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Services
{
    public class VideosService
    {

		private readonly AppDbContext _dbContext;
		public VideosService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ServiceResponse<Video> CadastrarNovo(VideoCreateRequest model)
		{
			Video novoVideo = new Video()
			{
				ResponsavelId = model.ReponsavelId,
				Titulo = model.Titulo,
				URL = model.URL,
				Idade = model.Idade

			};

			_dbContext.Add(novoVideo);
			_dbContext.SaveChanges();

			foreach (int id in model.CategoriaIds)
            {
				VideoCategoria item = new VideoCategoria()
				{
					VideoId = novoVideo.Id,
					CategoriaId = id
				};

				_dbContext.Add(item);
				_dbContext.SaveChanges();
			}

			return new ServiceResponse<Video>(novoVideo);
		}

		public IEnumerable<VideoResponse> ListarTodos()
		{
			
			List<Video> retornoDoBanco = _dbContext.Videos.ToList();

			List<VideoResponse> resposta = new List<VideoResponse>();

			foreach (Video item in retornoDoBanco)
            {
				List<CategoriaResponse> listaCategorias = _dbContext.VideoCategorias.Where(x => x.VideoId == item.Id).Select(x=> new CategoriaResponse(x.Categoria)).ToList();
				resposta.Add(new VideoResponse(item, listaCategorias));
			}

			return resposta;
		}

		public ServiceResponse<VideoResponse> PesquisarPorId(int id)
		{
			var resultado = _dbContext.Videos.FirstOrDefault(x => x.Id == id);
			List<CategoriaResponse> listaCategorias = _dbContext.VideoCategorias.Where(x => x.VideoId == resultado.Id).Select(x => new CategoriaResponse(x.Categoria)).ToList();
			if (resultado == null)
				return new ServiceResponse<VideoResponse>("Não encontrado!");
			else
				return new ServiceResponse<VideoResponse>(new VideoResponse(resultado, listaCategorias));
		}

		public ServiceResponse<VideoResponse> EditarURL(int id, VideoUpdateRequest model)
		{
			Video resultado = _dbContext.Videos.FirstOrDefault(x => x.Id == id);

			if (resultado == null)
				return new ServiceResponse<VideoResponse>("Video não encontrada!");

			resultado.URL = model.URL;
			_dbContext.Videos.Add(resultado).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return new ServiceResponse<VideoResponse>(new VideoResponse(resultado));
		}

	}
}
