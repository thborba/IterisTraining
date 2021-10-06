using System;

namespace URI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello URI!");
        }

        public void URI1050()
        {
            int ddd = int.Parse(Console.ReadLine());

            switch (ddd)
            {
                case 61:
                    Console.WriteLine("Brasilia");
                    break;
                case 71:
                    Console.WriteLine("Salvador");
                    break;
                case 11:
                    Console.WriteLine("Sao Paulo");
                    break;
                case 21:
                    Console.WriteLine("Rio de Janeiro");
                    break;
                case 32:
                    Console.WriteLine("Juiz de Fora");
                    break;
                case 19:
                    Console.WriteLine("Campinas");
                    break;
                case 27:
                    Console.WriteLine("Vitoria");
                    break;
                case 31:
                    Console.WriteLine("Belo Horizonte");
                    break;
                default:
                    Console.WriteLine("DDD nao cadastrado");
                    break;
            }
        }

        public void URI1074()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());

                string print;

                if (x == 0)
                    print = "NULL";
                else
                {
                    if (x % 2 == 0)
                        print = "ODD";
                    else
                        print = "EVEN";

                    if (x < 0)
                        print += " NEGATIVE";
                    else
                        print += " POSITIVE";
                }

                Console.WriteLine(print);
            }
        }

        public void URI1140()
        {
            string input = " ";
            do
            {
                input = Console.ReadLine();
                if (input != "*" && !string.IsNullOrWhiteSpace(input))
                {


                    string[] splited = input.ToLower().TrimStart().Split(' ');
                    bool aux = true;

                    if (splited != null)
                    {
                        char firstLetter = splited[0][0];
                        for (int i = 1; i < splited.Length; i++)
                        {
                            if (splited[i].Length > 20 || splited[i][0] != firstLetter || !Char.IsLetter(splited[i][0]))
                                aux = false;
                        }
                    }
                    else
                        aux = false;

                    if (aux == true)
                        Console.WriteLine("Y");
                    else
                        Console.WriteLine("N");

                }

            } while (input != "*");


        }

        public void URI1153()
        {
            int n = int.Parse(Console.ReadLine());

            int resultado = 1;

            while (n != 1)
            {
                resultado = resultado * n;
                n = n - 1;
            }

            Console.WriteLine(resultado);
        }

        public void URI1160()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splited = Console.ReadLine().Split(' ');

                int PA = int.Parse(splited[0]);
                int PB = int.Parse(splited[1]);
                double G1 = double.Parse(splited[2]);
                double G2 = double.Parse(splited[3]);

                int count = 0;

                while (PA <= PB && count <= 100)
                {
                    PA += (int)(PA * G1 / 100);
                    PB += (int)(PB * G2 / 100);
                    count++;
                }

                if (count > 100)
                    Console.WriteLine("Mais de 1 seculo.");
                else
                    Console.WriteLine(count + " anos.");

            }
        }



    }
}
