using System;
using System.Linq;



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
            //int[] diasFeriados = { };

            int[] diasFeriados = RetornaFeriados(mes, ano);
            //impressão do calendario

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
            for (int i = 0; i < diasFeriados.Length; i++)
            {
                if (diasFeriados[i] > 0)

                {
                    Console.Write($"{diasFeriados[i].ToString("D2")}\t");
                }
            }
        }


        public static int[] RetornaFeriados(int mes, int ano)
        {
            int[] feriados = new int[15];

            int indice = 0;
            //feriados[indice++] = 11;
            //feriados[indice++] = 21;

            if (mes == 1) feriados[indice++] = 1;

            else if (mes == 4)
            {
                feriados[indice++] = 4; //Aniversário de Marília
                feriados[indice++] = 21;  // Tiradentes
            }
            else if (mes == 5) feriados[indice++] = 1; // Dia do Trabalhador

            else if (mes == 7) feriados[indice++] = 9; // Revolução Constitucionalista (estadual)

            else if (mes == 9) feriados[indice++] = 7; // Independência

            else if (mes == 10) feriados[indice++] = 12;// Nossa Senhora Aparecida

            else if (mes == 11)
            {
                feriados[indice++] = 2; // Finados
                feriados[indice++] = 15; //Proclamação da República
                feriados[indice++] = 20; // Dia da Consciência Negra
            }
            else if (mes == 12)
            {
                feriados[indice++] = 8; // Dia da Padroeira de Marília
                feriados[indice++] = 25; // Natal
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

            return feriados;
        }


        public static DateTime CalcularPascoa(int ano)
        {
            int X = 0, Y = 0;

            // Ajustes históricos conforme o século
            if (ano <= 1699) { X = 22; Y = 2; }
            else if (ano <= 1799) { X = 23; Y = 3; }
            else if (ano <= 1899) { X = 24; Y = 4; }
            else if (ano <= 2099) { X = 24; Y = 5; }
            else if (ano <= 2199) { X = 24; Y = 6; }
            else if (ano <= 2299) { X = 24; Y = 7; }

            // Cálculos do algoritmo de Meeus/Jones/Butcher
            int a = ano % 19;
            int b = ano % 4;
            int c = ano % 7;
            int d = (19 * a + X) % 30;
            int g = (2 * b + 4 * c + 6 * d + Y) % 7;

            int dia;
            int mes;

            // Determina se a Páscoa cai em março ou abril
            if ((d + g) > 9)
            {
                dia = d + g - 9;
                mes = 4; // Abril
            }
            else
            {
                dia = d + g + 22;
                mes = 3; // Março
            }

            // Retorna a data da Páscoa
            return new DateTime(ano, mes, dia);
        }
    }
}

        /* Método que calcula a data da Páscoa
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
 }*/






    
     



