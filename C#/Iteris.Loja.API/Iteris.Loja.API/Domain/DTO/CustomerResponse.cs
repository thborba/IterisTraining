using Iteris.Loja.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.Domain.DTO
{
	public class CustomerResponse
	{
		public CustomerResponse(Customer baseModel)
		{
			Id = baseModel.Id;
			FirstName = baseModel.FirstName;
			LastName = baseModel.LastName;
		}
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
