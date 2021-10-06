using Iteris.Loja.API.DAL.Repositories;
using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Domain.Entity;
using Iteris.Loja.API.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.Services
{
	public class CustomersService
	{
		private readonly CustomersRepository _customersRepository;

		public CustomersService(CustomersRepository customersRepository)
		{
			_customersRepository = customersRepository;
		}

		public async Task<ServiceResponse<CustomerResponse>> PesquisaPorId(int id)
		{
			var customer = await _customersRepository.PesquisaPorId(id);
			if (customer != null)
			{
				return new ServiceResponse<CustomerResponse>(new CustomerResponse(customer));
			}
			return new ServiceResponse<CustomerResponse>("Não encontrado");
		}

		// se o metodo é async sempre devemos retornar uma Task
		public async Task<ServiceResponse<CustomerResponse>> Cadastrar(CustomerCreateRequest novo)
		{
			var modeloDb = new Customer
			{
				FirstName = novo.FirstName,
				LastName = novo.LastName,
				City = novo.City,
				Country = novo.Country,
				Phone = novo.Phone
			};

			await _customersRepository.Cadastrar(modeloDb);

			return new ServiceResponse<CustomerResponse>(new CustomerResponse(modeloDb));
		}

		public async Task<ServiceResponse<List<CustomerResponse>>> Pesquisar(int paginaAtual, int qtdPagina)
		{
			if (paginaAtual < 0)
			{
				return new ServiceResponse<List<CustomerResponse>>("O indice da página atual deve começar em 0");
			}

			if (qtdPagina < 1 || qtdPagina > 50)
			{
				return new ServiceResponse<List<CustomerResponse>>("Quantidade de itens por página deve ser entre 1 e 50 itens");
			}


			var listaPesquisa = await _customersRepository.Pesquisar(paginaAtual, qtdPagina);
			var listaConvertida = listaPesquisa.Select(x => new CustomerResponse(x)).ToList();

			return new ServiceResponse<List<CustomerResponse>>(listaConvertida);
		}

	}
}
