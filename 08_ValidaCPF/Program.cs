
using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite seu CPF: ");
        string entrada = Console.ReadLine();

        // Remove qualquer caractere que não seja número
        string cpf = Regex.Replace(entrada, "[^0-9]", "");

        if (ValidarCPF(cpf))
        {
            Console.WriteLine("CPF válido!");
        }
        else
        {
            Console.WriteLine("CPF inválido.");
        }
    }

    static bool ValidarCPF(string cpf)
    {
        // Verifica se tem 11 dígitos e se todos são números
        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            return false;

        // Verifica se todos os dígitos são iguais (ex: 11111111111)
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcula o primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (cpf[i] - '0') * (10 - i);

        int resto = soma % 11;
        int digito1 = (resto < 2) ? 0 : 11 - resto;

        // Calcula o segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (cpf[i] - '0') * (11 - i);

        resto = soma % 11;
        int digito2 = (resto < 2) ? 0 : 11 - resto;

        // Verifica se os dígitos calculados são iguais aos informados
        return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
    }
}



