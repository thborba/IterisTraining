﻿using Iteris.Loja.API.DAL.Repositories;
using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Domain.Entity;
using Iteris.Loja.API.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Loja.API.Services
{
	public class PurchasesService
	{
		private readonly ProductsRepository _productsRepository;
		private readonly OrdersRepository _ordersRepository;
		private readonly OrderItemsRepository _orderItemsRepository;
		private readonly CustomersRepository _customersRepository;

		public PurchasesService(ProductsRepository productsRepository, OrdersRepository ordersRepository, OrderItemsRepository orderItemsRepository, CustomersRepository customersRepository)
		{
			_productsRepository = productsRepository;
			_ordersRepository = ordersRepository;
			_orderItemsRepository = orderItemsRepository;
			_customersRepository = customersRepository;
		}

		public async Task<ServiceResponse<PurchaseResponse>> Cadastrar(PurchaseCreateRequest novo)
		{
			// criar objeto padrão que vamos criar aos poucos
			Order novaOrder = new Order();
			List<OrderItem> listaOrderItens = new List<OrderItem>();


			//Criar validações
			// validar se Customer / Cliente existe com o id informado
			var customer = await _customersRepository.PesquisaPorId(novo.CustomerId);
			if (customer == null)
			{
				return new ServiceResponse<PurchaseResponse>("Cliente não encontrado. ID " + novo.CustomerId);
			}
			// validar se existem itens na ordem de compra
			if (novo.Itens == null || !novo.Itens.Any())
			{
				return new ServiceResponse<PurchaseResponse>("A compra deve ter pelomenos 1 item de compra");
			}

			//Até este ponto isso está ok
			//Vamos preeencher o novo objeto
			novaOrder.CustomerId = novo.CustomerId;
			novaOrder.OrderDate = new DateTime();

			//Mais validação
			//validar a integridade de cada item de compra
			foreach (var item in novo.Itens)
			{
				//objeto que vai ser populado
				var orderItem = new OrderItem();

				// validar quantidade
				if (item.Quantity < 1)
				{
					return new ServiceResponse<PurchaseResponse>("ID : " + item.ProductId + "Quantidade do produto deve maior do que 0.");
				}
				else
				{
					orderItem.Quantity = item.Quantity;
				}


				// validar se o produto existe
				// também valida se é um produto ativo
				var product = await _productsRepository.PesquisaPorId(item.ProductId);

				if (product == null)
				{
					return new ServiceResponse<PurchaseResponse>("ID : " + item.ProductId + " Produto não encontrado.");
				}
				else if (product.IsDiscontinued)
				{
					return new ServiceResponse<PurchaseResponse>("ID : " + item.ProductId + " Produto não está mais disponível");
				}
				else
				{
					orderItem.ProductId = item.ProductId;
					orderItem.UnitPrice = product.UnitPrice.Value;
				}

				if (item.Discount.HasValue && item.Discount != 0)
				{
					//para evitar problemas de ponto flutuante
					int descontoInteiro = (int)(item.Discount.Value * 100);


					if ((item.Quantity >= 500 && descontoInteiro >= 0 && descontoInteiro <= 30) || (item.Quantity >= 100 && descontoInteiro >= 0 && descontoInteiro <= 20) || (item.Quantity >= 25 && descontoInteiro >= 0 && descontoInteiro <= 10))
					{
						//atualizar o valor com desconto
						orderItem.UnitPrice = (orderItem.UnitPrice * (decimal)(1 - item.Discount.Value));
					}
					else
					{
						return new ServiceResponse<PurchaseResponse>("ID : " + item.ProductId + " Desconto inválido!");
					}
				}

				listaOrderItens.Add(orderItem);
			}


			//Terminar de montar objeto
			// calcular valor total
			decimal valorTotal = 0;
			foreach (var itemCompra in listaOrderItens)
			{
				valorTotal += itemCompra.UnitPrice * itemCompra.Quantity;
			}
			novaOrder.TotalAmount = valorTotal;

			// salvar primeiro o order para definir um id
			await _ordersRepository.Cadastrar(novaOrder);

			//Atualiza os orders itens com o id da order
			foreach (var itemCompra in listaOrderItens)
			{
				itemCompra.OrderId = novaOrder.Id;
			}

			//salvar no banco os orderItens
			await _orderItemsRepository.CadastrarVarios(listaOrderItens);


			return new ServiceResponse<PurchaseResponse>(new PurchaseResponse(novaOrder));
		}
	}
}
