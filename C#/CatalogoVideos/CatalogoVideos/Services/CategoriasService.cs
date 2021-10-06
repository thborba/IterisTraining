using CatalogoVideos.DAL;
using CatalogoVideos.Domain.DTO;
using CatalogoVideos.Domain.DTO.Categorias;
using CatalogoVideos.Domain.Entity;
using CatalogoVideos.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.Services
{
    public class CategoriasService
    {

		private readonly AppDbContext _dbContext;
		public CategoriasService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ServiceResponse<Categoria> CadastrarNovo(CategoriaCreateRequest model)
		{
			Categoria novaCategoria = new Categoria()
			{
				Nome = model.Nome,
			};

			_dbContext.Add(novaCategoria);
			_dbContext.SaveChanges();

			return new ServiceResponse<Categoria>(novaCategoria);
		}

		public IEnumerable<CategoriaResponse> ListarTodos()
		{

			List<Categoria> retornoDoBanco = _dbContext.Categorias.ToList();

			IEnumerable<CategoriaResponse> lista = retornoDoBanco.Select(x => new CategoriaResponse(x));

			return lista;
		}

	}
}
