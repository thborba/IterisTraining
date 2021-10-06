using AdotaAnimais.Domain.DTO;
using AdotaAnimais.Domain.Entity;
using AdotaAnimais.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdotaAnimais.Services
{
    public class AnimalService
    {

		private static List<Animal> lista; 
		private static int proximoId = 1;

		public AnimalService()
		{
			lista = new List<Animal>();
		}

		public ServiceResponse<Animal> CadastrarNovo(AnimalCreateRequest model)
		{

			if (model.Especie != "Cachorro" && model.Especie != "Capivara" && model.Especie != "Gato" && model.Especie != "Coelho")
				return new ServiceResponse<Animal>("Somente é possível cadastrar animais com essas espécies: Cachorro, Gato, Coelho e Capivara");

			if (!model.Idade.HasValue)
				return new ServiceResponse<Animal>("A idade é obrigatória");

            if (model.Fofura < 1 || model.Fofura > 5)
                return new ServiceResponse<Animal>("O nível de fofura deve ser um número entre 1 a 5");

			if (model.Carinho < 1 || model.Carinho > 5)
                return new ServiceResponse<Animal>("O nível de carinho deve ser um número entre 1 a 5");

            Animal novoAnimal = new Animal()
			{
				Id = proximoId++,
				Nome = model.Nome,
				Email = model.Email,
				Idade = model.Idade.Value,
				Fofura = model.Fofura,
				Carinho = model.Carinho,
				DataNascimento = model.DataNascimento
				
			};

			lista.Add(novoAnimal);

			return new ServiceResponse<Animal>(novoAnimal);
		}

		public List<Animal> ListarTodos()
		{
			return lista;
		}

		public ServiceResponse<Animal> PesquisarPorId(int id)
		{

			var resultado = lista.Where(x => x.Id == id).FirstOrDefault();
			if (resultado == null)
				return new ServiceResponse<Animal>("Não encontrado!");
			else
				return new ServiceResponse<Animal>(resultado);

		}

		public ServiceResponse<Animal> PesquisarPorNome(string nome)
		{
			var resultado = lista.Where(x => x.Nome == nome).FirstOrDefault();
			if (resultado == null)
				return new ServiceResponse<Animal>("Não encontrado!");
			else
				return new ServiceResponse<Animal>(resultado);
		}

		public ServiceResponse<Animal> Editar(int id, AnimalUpdateRequest model)
		{
			var resultado = lista.Where(x => x.Id == id).FirstOrDefault();

			if (resultado == null)
				return new ServiceResponse<Animal>("Animal não encontrado!");

			resultado.Nome = model.Nome;

			return new ServiceResponse<Animal>(resultado);
		}

		public ServiceResponse<bool> Deletar(int id)
		{
			var resultado = lista.Where(x => x.Id == id).FirstOrDefault();

			if (resultado == null)
				return new ServiceResponse<bool>("Animal não encontrado!");

			lista.Remove(resultado);

			return new ServiceResponse<bool>(true);
		}
	}
}
