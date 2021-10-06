using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdotaAnimais.Domain.Entity
{
    public class Animal
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Especie { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int Fofura { get; set; }
        public int Carinho { get; set; }
        public string Email { get; set; }
    }
}
