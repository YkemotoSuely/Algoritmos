using System;
 

namespace CorreçãoExercicioDownload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tamanhoMB = 0;
            double velocidadeMbps = 0;
            double tempoSegundos, tempoMinutos;

            //loop infinito
            while (true)
            {
                //operadores lógicos
                //&& -> AND (E logico)
                //|| -> OR (OU lógico)

                Console.Write("Informe o tamanho do arquivo (MB): ");
                if (double.TryParse(Console.ReadLine(), out tamanhoMB) && tamanhoMB > 0)
                    // sai do loop
                    break;
                else
                    Console.WriteLine("Valor inválido! Digite um número maior que zero.");
            }
            while (true)
            {

                Console.Write("Informe a velocidade da internet (Mbps): ");
                if (double.TryParse(Console.ReadLine(), out velocidadeMbps) && velocidadeMbps > 0)
                    // sai do loop
                    break;
                else
                    Console.WriteLine("Valor inválido! Digite um número maior que zero.");
            }
            //cálculo do tempo
            tempoSegundos = (tamanhoMB *8) / velocidadeMbps;
            tempoMinutos = tempoSegundos / 60;

            Console.WriteLine($"Tempo aproximado de download: {tempoMinutos:F2}minutos");



        }

        }
    }
}
