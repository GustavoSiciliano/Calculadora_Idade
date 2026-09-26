using System;

namespace Calculadora_Idade.Services
{
    internal static class IdadeService
    {
        public static int CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Today;

            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento.Date > dataAtual.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

        public static bool MaiorDeIdade(int idade)
        {
            return idade >= 18;
        }
    }
}