using System;


namespace _09_Calendario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o mês (1 a 12): ");
            int mes = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ano: ");
            int ano = int.Parse(Console.ReadLine());

            //Descobre a qtde de dias do mês
            int diasDoMes = DateTime.DaysInMonth(ano, mes);

            // descobre o dia da semana do 1º dia do mês
            // 0 = domingo - 6 = sábado
            // informa o primeiro dia do mês e ano informado pelo usuário
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);
            int diaSemanaInicio = (int)primeiroDiaMes.DayOfWeek;

            // matriz de 6 semanas e 7 dias
            int[,] calendario = new int[6, 7];


            int dia = 1;

            // preenche a matriz com os dias do mês

            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (semana == 0 && diaSemana < diaSemanaInicio)
                    {
                        calendario[semana, diaSemana] = 0;
                    }
                    else if (dia <= diasDoMes)
                    {
                        calendario[semana, diaSemana] = dia;
                        dia++;
                    }
                }

            }

            // Imprime o cabeçalho do calendário
            Console.WriteLine("\nCalendário de " + primeiroDiaMes.ToString("MMMM") + " de " + ano);

            Console.WriteLine("Dom\tSeg\tTer\tQua\tQui\tSex\tSab");

            // Imprime os dias do mês


            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (calendario[semana, diaSemana] == 0)
                    {
                        Console.Write("    ");
                    }
                    else
                    {
                        Console.Write(calendario[semana, diaSemana].ToString("D2") + "\t");
                    }
                }
                Console.WriteLine();
            }


        }
    }
}
     



