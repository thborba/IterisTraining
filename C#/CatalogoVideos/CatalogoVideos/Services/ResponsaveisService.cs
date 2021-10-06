using CatalogoVideos.DAL;
using CatalogoVideos.Domain.DTO;
using CatalogoVideos.Domain.Entity;
using CatalogoVideos.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Services
{
    public class ResponsaveisService
    {

		private readonly AppDbContext _dbContext;
		public ResponsaveisService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ServiceResponse<Responsavel> CadastrarNovo(ResponsavelCreateRequest model)
		{
			Responsavel novaResponsavel = new Responsavel()
			{
				Nome = model.Nome,
			};

			_dbContext.Add(novaResponsavel);
			_dbContext.SaveChanges();

			return new ServiceResponse<Responsavel>(novaResponsavel);
		}

		public ServiceResponse<ResponsavelResponse> PesquisarPorId(int id)
		{
			var resultado = _dbContext.Responsaveis.FirstOrDefault(x => x.Id == id);
			if (resultado == null)
				return new ServiceResponse<ResponsavelResponse>("Não encontrado!");
			else
				return new ServiceResponse<ResponsavelResponse>(new ResponsavelResponse(resultado));
		}
	}
}
