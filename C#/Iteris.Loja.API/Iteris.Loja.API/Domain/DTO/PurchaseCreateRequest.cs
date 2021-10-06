using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.Domain.DTO
{
	public class PurchaseCreateRequest
	{
		[Required]
		public int CustomerId { get; set; }

		[Required]
		public IEnumerable<PurchaseItem> Itens { get; set; }
	}
}
