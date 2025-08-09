using System;


namespace _06_Tabuada
{
    internal class Program
    {
        static void Main(string[] args)

     
            {
                int multiplicador, multiplicando = 0, resultado = 0;

                Console.WriteLine("Digite um número inteiro: ");
                multiplicador = int.Parse(Console.ReadLine());

                while (multiplicando <= 10)
                {
                    resultado = multiplicador * multiplicando;
                    Console.WriteLine($"{multiplicador} X {multiplicando} = {resultado}");
                    multiplicando++;
                }
            }
        }
    }

