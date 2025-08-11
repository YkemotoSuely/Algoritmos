using System;


namespace TabuadaExemploCelso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int multiplicando = 0, produto;
            bool digitacaoValida = false;

            // !negação: inverte o valor booleano
            // !false = True
            // !true = false
            // while (digitacoValida)
            while (!digitacaoValida)
            {
                Console.WriteLine("Digite um número inteiro:");
                digitacaoValida = int.TryParse(Console.ReadLine(), out multiplicando);
            }

            //Console.WriteLine("Tabiada do {0}", multiplicando);
            //Interpolação de Strin $
            Console.WriteLine($"Tabuada do {multiplicando}");
            for (int multiplicador = 1; multiplicador <= 10; multiplicador++)
            { 
                produto = multiplicando * multiplicador;
                // Console.WriteLine("{0} X {1} = {2}", multiplicando, multiplicador, produto);
                Console.WriteLine($"{multiplicando} X {multiplicador} = {produto}");
            }
        }
    }
}
