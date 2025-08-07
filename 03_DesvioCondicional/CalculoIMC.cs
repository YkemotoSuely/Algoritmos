using System;

class CalculoIMC 
{
		static void Main ()
		{
			double peso,altura,imc;
			
			Console.WriteLine("Digite seu peso (KG): ");
			//Console.ReadLine() é equivalente ao LEIA do Portugol
			peso = Double.Parse( Console.ReadLine() );
			
			Console.WriteLine("Digite sua altura (m)");
			altura = Double.Parse( Console.ReadLine() );
			
			imc = peso / (altura * altura);
			
			Console.WriteLine("Seu IMC é {0:F3}", imc);
			
			if (imc < 18.5 )
			{
				Console.WriteLine ("Classificação: Abaixo do peso");
			}else if (imc <25)
			{
				Console.WriteLine ("Classificação: Peso Normal");
			}else
			{
				Console.WriteLine ("Classificação: Acima do peso");
			}
			
		}
	
}