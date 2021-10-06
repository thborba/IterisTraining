using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroPrograma.Modelos
{
    public class Cliente
    {

        public Cliente()
        {

        }

        public Cliente(int idade) {
            this.idade = idade;
        }

        private int idade;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string FaltaQuantosAnosPara(int idadeAlvo)
        {
            int diferenca = idadeAlvo - idade;
            if (diferenca >= 0)
               return "Falta(m) " + diferenca + " Anos(s)";
            else
               return "Já passou da idade";
        }

        public string NomeCompleto()
        {

            return Nome + " " + Sobrenome;
        }

    }
}
