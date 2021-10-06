using Iteris.Loja.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.Domain.DTO
{
	public class PurchaseResponse
	{
		public PurchaseResponse(Order order)
		{
			Id = order.Id;
			OrderDate = order.OrderDate;
			TotalAmount = order.TotalAmount.Value;
		}

		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
