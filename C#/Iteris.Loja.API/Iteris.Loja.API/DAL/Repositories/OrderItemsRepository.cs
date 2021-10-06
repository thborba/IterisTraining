using Iteris.Loja.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.DAL.Repositories
{
	public class OrderItemsRepository
	{
		private readonly IterisLojaContext _lojaContext;

		public OrderItemsRepository(IterisLojaContext lojaContext)
		{
			_lojaContext = lojaContext;
		}

		public async Task<List<OrderItem>> CadastrarVarios(List<OrderItem> novo)
		{
			_lojaContext.OrderItems.AddRange(novo);
			await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
			return novo;
		}
	}
}
