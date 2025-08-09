using System;


namespace _04__Vetores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaração de variável
            // sintaxe: tipo nomeVariável = valor
            string nome = "Fulano de Tal";

            //reatribuição de valor em uma variável
            nome = "Beltrano";
            Console.WriteLine(nome);

            //declaração de vetores
            // sintaxe: tipo[] nomeVariavel = {valor1, valor2, valor3,};
            string[] nomes = { "Fulano de tal", "Beltrano", "Sicrano", "João", "José", "Maria"};
            Console.WriteLine(nomes[0]);
            Console.WriteLine(nomes[1]);
            Console.WriteLine(nomes[2]);

            //Loop FOR
            // Sintaxe: for(indice; controle; incremento)
            for (int i = 0; i < nomes.Length; i++) 
            {
                Console.WriteLine("{0}º Nome: {1}", i+1, nomes[i]);
            }

            //Impressão dos 100 primeiros números pares
            for (int i = 0; i <= 100; i += 2)
            {
                Console.WriteLine("Número: {0}", i);
            }
            // Loop FOREACH
            // Sintaxe: foreach(variavel in vetor)
            foreach (string varNome in nomes)
            {
                Console.WriteLine("Nome: {0}", varNome);
            }
        }
    }
}
/*
 * Ctrl + .: Abre a janela de exceções, permitindo que você configure o Visual Studio para parar em exceções específicas. 

Ctrl + K, Ctrl + C: Comenta a seleção de código. 

Ctrl + K, Ctrl + U: Descomenta a seleção de código. 

F12: Vai para a definição do objeto onde o cursor está posicionado. 

F9: Adiciona ou remove um ponto de interrupção na linha de código atual. 

Ctrl + Shift + B: Compila a solução. 

Ctrl + F5: Inicia a depuração sem depurar. 

Ctrl + S: Salva o arquivo atual. 

Ctrl + Shift + N: Cria um novo projeto. 

Ctrl + Shift + O: Abre um arquivo existente. 
*/