using System;
using System.Globalization;
using Calculadora_Idade.Models;
using Calculadora_Idade.Services;

namespace Calculadora_Idade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CALCULADORA DE IDADE ===");
            Console.WriteLine();

            Console.Write("Digite seu nome completo: ");
            string nome = Console.ReadLine();

            DateTime dataNascimento;

            while (true)
            {
                Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
                string entradaData = Console.ReadLine();

                if (DateTime.TryParseExact(
                    entradaData,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dataNascimento))
                {
                    if (dataNascimento <= DateTime.Today)
                    {
                        break;
                    }

                    Console.WriteLine("A data de nascimento não pode ser futura.");
                }
                else
                {
                    Console.WriteLine("Data inválida. Digite no formato dd/MM/yyyy.");
                }

                Console.WriteLine();
            }

            Pessoa pessoa = new Pessoa(nome, dataNascimento);

            int idade = IdadeService.CalcularIdade(pessoa.DataNascimento);

            Console.WriteLine();
            Console.WriteLine("=== RESULTADO ===");
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Data de nascimento: {pessoa.DataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Idade: {idade} anos");

            if (IdadeService.MaiorDeIdade(idade))
            {
                Console.WriteLine("Você é maior de idade.");
                Console.WriteLine("Você pode realizar o procedimento para tirar a carteira de habilitação.");
            }
            else
            {
                Console.WriteLine("Você é menor de idade.");
                Console.WriteLine("Você ainda não pode realizar o procedimento para tirar a carteira de habilitação.");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}