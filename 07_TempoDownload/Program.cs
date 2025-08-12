using System;

 class Program
    {
        static void Main(string[] args)
        {
            double tamanhoMB, velocidadeMbps;

            Console.WriteLine("Digite o tamanho do seu arquivo em megabytes: ");
            string valorDigitado = Console.ReadLine();

            if (double.TryParse(valorDigitado, out tamanhoMB) && tamanhoMB > 0)
            {
                Console.WriteLine("Digite a velocidade da sua internet em Mbps: ");
                valorDigitado = Console.ReadLine();

                if (double.TryParse(valorDigitado, out velocidadeMbps) && velocidadeMbps > 0)
                {
                    double tempoSegundos = (tamanhoMB * 8) / velocidadeMbps;
                    double tempoMinutos = tempoSegundos / 60;

                    Console.WriteLine($"Tempo aproximado de download: {tempoMinutos:F2} minutos");
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um valor maior que zero.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido! Digite um valor maior que zero.");
            }
        }
    }

