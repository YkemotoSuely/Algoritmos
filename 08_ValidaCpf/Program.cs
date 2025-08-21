using System;
using System.Linq;
using System.Text.RegularExpressions;
/*
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite seu CPF: ");
        string entrada = Console.ReadLine();

        // Remove qualquer caractere que não seja número
        string cpf = Regex.Replace(entrada, "[^0-9]", "");

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            Console.WriteLine("CPF inválido. Certifique-se de digitar 11 números.");
            return;
        }

        if (cpf.Distinct().Count() == 1)
        {
            Console.WriteLine("CPF inválido. Todos os dígitos são iguais.");
            return;
        }

        // Cálculo do primeiro dígito verificador
        int soma1 = 0;
        Console.WriteLine("\nCálculo do 1º dígito verificador:");
        for (int i = 0; i < 9; i++)
        {
            int peso = 10 - i;
            int valor = (cpf[i] - '0') * peso;
            soma1 += valor;
            Console.WriteLine($"{cpf[i]} × {peso} = {valor}");
        }

        int resto1 = soma1 % 11;
        int digito1 = (resto1 < 2) ? 0 : 11 - resto1;
        Console.WriteLine($"Soma: {soma1}, Resto: {resto1}, 1º dígito verificador: {digito1}");

        // Cálculo do segundo dígito verificador
        int soma2 = 0;
        Console.WriteLine("\nCálculo do 2º dígito verificador:");
        for (int i = 0; i < 10; i++)
        {
            int peso = 11 - i;
            int valor = (cpf[i] - '0') * peso;
            soma2 += valor;
            Console.WriteLine($"{cpf[i]} × {peso} = {valor}");
        }

        int resto2 = soma2 % 11;
        int digito2 = (resto2 < 2) ? 0 : 11 - resto2;
        Console.WriteLine($"Soma: {soma2}, Resto: {resto2}, 2º dígito verificador: {digito2}");

        // Verificação final
        if ((cpf[9] - '0') == digito1 && (cpf[10] - '0') == digito2)
        {
            Console.WriteLine("\n✅ CPF válido!");
        }
        else
        {
            Console.WriteLine("\n❌ CPF inválido! Dígitos verificadores não conferem.");
        }
    }
}*/



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Deseja ver o passo a passo do cálculo dos dígitos verificadores? (s/n)");
        string mostrarPasso = Console.ReadLine()?.Trim().ToLower();

        Console.WriteLine("\nDigite seu CPF: ");
        string entrada = Console.ReadLine();

        // Remove qualquer caractere que não seja número
        string cpf = Regex.Replace(entrada, "[^0-9]", "");

        bool mostrarDetalhes = mostrarPasso == "s";

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            Console.WriteLine("CPF inválido. Certifique-se de digitar 11 números.");
            return;
        }

        if (cpf.Distinct().Count() == 1)
        {
            Console.WriteLine("CPF inválido. Todos os dígitos são iguais.");
            return;
        }

        // Cálculo do primeiro dígito verificador
        int soma1 = 0;
        if (mostrarDetalhes) Console.WriteLine("\nCálculo do 1º dígito verificador:");
        for (int i = 0; i < 9; i++)
        {
            int peso = 10 - i;
            int valor = (cpf[i] - '0') * peso;
            soma1 += valor;
            if (mostrarDetalhes) Console.WriteLine($"{cpf[i]} × {peso} = {valor}");
        }

        int resto1 = soma1 % 11;
        int digito1 = (resto1 < 2) ? 0 : 11 - resto1;
        if (mostrarDetalhes) Console.WriteLine($"Soma: {soma1}, Resto: {resto1}, 1º dígito verificador: {digito1}");

        // Cálculo do segundo dígito verificador
        int soma2 = 0;
        if (mostrarDetalhes) Console.WriteLine("\nCálculo do 2º dígito verificador:");
        for (int i = 0; i < 10; i++)
        {
            int peso = 11 - i;
            int valor = (cpf[i] - '0') * peso;
            soma2 += valor;
            if (mostrarDetalhes) Console.WriteLine($"{cpf[i]} × {peso} = {valor}");
        }

        int resto2 = soma2 % 11;
        int digito2 = (resto2 < 2) ? 0 : 11 - resto2;
        if (mostrarDetalhes) Console.WriteLine($"Soma: {soma2}, Resto: {resto2}, 2º dígito verificador: {digito2}");

        // Verificação final
        if ((cpf[9] - '0') == digito1 && (cpf[10] - '0') == digito2)
        {
            Console.WriteLine("\n✅ CPF válido!");
        }
        else
        {
            Console.WriteLine("\n❌ CPF inválido! Dígitos verificadores não conferem.");
        }
    }
}

