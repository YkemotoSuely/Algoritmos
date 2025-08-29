using System;
using System.Linq;

namespace _09_Calendario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o ano: ");
            int ano = int.Parse(Console.ReadLine());

            for (int mes = 1; mes <= 12; mes++)
            {
                int[,] calendario = GerarCalendario(mes, ano);
                ImprimeCalendario(calendario, mes, ano);
            }
        }

        // ------------------ NOVOS MÉTODOS ------------------

        public static int[,] GerarCalendario(int mes, int ano)
        {
            int diasDoMes = DateTime.DaysInMonth(ano, mes);
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);
            int diaSemanaInicio = (int)primeiroDiaMes.DayOfWeek;

            int[,] calendario = new int[6, 7];
            int dia = 1;

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
            return calendario;
        }

        public static void ImprimeCalendario(int[,] calendario, int mes, int ano)
        {
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);

            Console.WriteLine("\nCalendário de " + primeiroDiaMes.ToString("MMMM") + " de " + ano);
            Console.WriteLine("Dom\tSeg\tTer\tQua\tQui\tSex\tSab");

            int[] diasFeriados = RetornaFeriados(mes, ano);

            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (calendario[semana, diaSemana] != 0)
                    {
                        if (diasFeriados.Contains(calendario[semana, diaSemana]) || diaSemana == 0)
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(calendario[semana, diaSemana].ToString("D2") + "\t");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("\nFeriados: ");
            foreach (int f in diasFeriados.Where(x => x > 0))
            {
                Console.Write($"{f:D2}\t");
            }
            Console.WriteLine("\n");
        }

        // ------------------ MÉTODOS AUXILIARES ------------------

        public static int[] RetornaFeriados(int mes, int ano)
        {
            int[] feriados = new int[15];
            int indice = 0;

            if (mes == 1) feriados[indice++] = 1;
            else if (mes == 4)
            {
                feriados[indice++] = 4;
                feriados[indice++] = 21;
            }
            else if (mes == 5) feriados[indice++] = 1;
            else if (mes == 7) feriados[indice++] = 9;
            else if (mes == 9) feriados[indice++] = 7;
            else if (mes == 10) feriados[indice++] = 12;
            else if (mes == 11)
            {
                feriados[indice++] = 2;
                feriados[indice++] = 15;
                feriados[indice++] = 20;
            }
            else if (mes == 12)
            {
                feriados[indice++] = 8;
                feriados[indice++] = 25;
            }

            // Feriados móveis
            DateTime pascoa = CalcularPascoa(ano);
            DateTime carnaval = pascoa.AddDays(-47);
            DateTime sextaSanta = pascoa.AddDays(-2);
            DateTime corpusChristi = pascoa.AddDays(60);

            if (pascoa.Month == mes) feriados[indice++] = pascoa.Day;
            if (carnaval.Month == mes) feriados[indice++] = carnaval.Day;
            if (sextaSanta.Month == mes) feriados[indice++] = sextaSanta.Day;
            if (corpusChristi.Month == mes) feriados[indice++] = corpusChristi.Day;

            Array.Sort(feriados);
            return feriados;
        }

        public static DateTime CalcularPascoa(int ano)
        {
            int X = 0, Y = 0;

            if (ano <= 1699) { X = 22; Y = 2; }
            else if (ano <= 1799) { X = 23; Y = 3; }
            else if (ano <= 1899) { X = 24; Y = 4; }
            else if (ano <= 2099) { X = 24; Y = 5; }
            else if (ano <= 2199) { X = 24; Y = 6; }
            else if (ano <= 2299) { X = 24; Y = 7; }

            int a = ano % 19;
            int b = ano % 4;
            int c = ano % 7;
            int d = (19 * a + X) % 30;
            int g = (2 * b + 4 * c + 6 * d + Y) % 7;

            int dia, mes;

            if ((d + g) > 9)
            {
                dia = d + g - 9;
                mes = 4;
            }
            else
            {
                dia = d + g + 22;
                mes = 3;
            }

            return new DateTime(ano, mes, dia);
        }
    }
}
