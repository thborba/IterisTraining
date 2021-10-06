using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeiroPrograma.Modelos
{
    public class Usuario
    {

        public string Nome { get; set; }
        public string Email { get; set; }

        public string ObterLogin()
        {
            string[] split = Email.Split("@");

            return split[0];
        }
    }
}
