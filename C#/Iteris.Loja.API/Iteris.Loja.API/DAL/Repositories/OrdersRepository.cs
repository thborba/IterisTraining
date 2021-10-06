using Iteris.Loja.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.DAL.Repositories
{
	public class OrdersRepository
	{
		private readonly IterisLojaContext _lojaContext;

		public OrdersRepository(IterisLojaContext lojaContext)
		{
			_lojaContext = lojaContext;
		}

		public async Task<Order> Cadastrar(Order novo)
		{
			_lojaContext.Orders.Add(novo);
			await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
			return novo;
		}
	}
}
