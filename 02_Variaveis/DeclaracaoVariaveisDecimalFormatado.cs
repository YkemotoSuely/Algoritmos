using System;

class DeclaracaoVariaveisDecimalFormatado
{
    static void Main(string[] args)
    {
        decimal x = 0.999m;
        decimal y = 9999999999999999999999999999m;		
		/*
		Utilizando Placeholder para demonstrar o conteúdo
		de uma variável no texto
		{0:C)
		0 = posição de marcação
		C = Formatação de Moeda (Currency)
		*/
        Console.WriteLine("Minha quantia = {0:C}", x);
        Console.WriteLine("Sua quantia = {0:C}", y);		
		Console.WriteLine("Valor de x = {0:F3} e Valor de y = {1:C}",x,y);
		
		/*
		Interpolação de String, só funciona no .Net versão 6.0 acima
		*/		
		/*
		Console.WriteLine($"Minha quantia = {x:C}");
        Console.WriteLine($"Sua quantia = {y:C}");		
		Console.WriteLine($"Valor de x = {x:F3} e Valor de y = {y:C}");
		*/
    }
}

