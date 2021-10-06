using Iteris.Loja.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.DAL.Repositories
{
	public class CustomersRepository
	{
		private readonly IterisLojaContext _lojaContext;

		public CustomersRepository(IterisLojaContext lojaContext)
		{
			_lojaContext = lojaContext;
		}

		//Async é a forma de usar programação assincrona
		//Isso otimiza o uso do processador
		public async Task<Customer> PesquisaPorId(int id)
		{
			// select top 1 * from Customers
			return await _lojaContext.Customers.FindAsync(id);
		}

		// se o metodo é async sempre devemos retornar uma Task
		public async Task<Customer> Cadastrar(Customer novo)
		{
			_lojaContext.Customers.Add(novo);
			await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
			return novo;
		}

		public async Task<List<Customer>> Pesquisar(int paginaAtual, int qtdPagina)
		{

			// Estou na página 4 (começando em 0), e tem 20 itens por página
			// descarto os primeiro 80, pego os próximos 20
			int qtaPaginasAnteriores = paginaAtual * qtdPagina;

			return await _lojaContext.Customers.Skip(qtaPaginasAnteriores).Take(qtdPagina).ToListAsync();
		}
	}
}
