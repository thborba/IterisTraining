using PrimeiroPrograma.Coisas;
using PrimeiroPrograma.Modelos;
using System;

namespace PrimeiroPrograma
{
    class Program
    {
        static void Main(string[] args) 
        {
            Cliente clienteA = new Cliente();
            clienteA.Nome = "Douglas";
            clienteA.Sobrenome = "Fernandes";

            Console.WriteLine(clienteA.NomeCompleto());
            Console.WriteLine(clienteA.FaltaQuantosAnosPara(40));

            Cliente clienteB = new Cliente(20); 
            clienteB.Nome = "Thiago";
            clienteB.Sobrenome = "Borba";

            Console.WriteLine(clienteB.NomeCompleto());
            Console.WriteLine(clienteB.FaltaQuantosAnosPara(40));


            Usuario usuario = new Usario();
            usuario.Nome = "Thiago";
            usuario.Email = "thiago.borba@iteris.com.br";

            Console.WriteLine(usuario.ObterLogin());
        }

    }
}
