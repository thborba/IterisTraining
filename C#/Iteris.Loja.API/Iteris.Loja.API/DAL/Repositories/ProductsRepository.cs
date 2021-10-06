using Iteris.Loja.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.DAL.Repositories
{
	public class ProductsRepository
	{
		private readonly IterisLojaContext _lojaContext;

		public ProductsRepository(IterisLojaContext lojaContext)
		{
			_lojaContext = lojaContext;
		}

		//Async é a forma de usar programação assincrona
		//Isso otimiza o uso do processador
		public async Task<Product> PesquisaPorId(int id)
		{
			// select top 1 * from Customers
			return await _lojaContext.Products.FindAsync(id);
		}
	}
}
