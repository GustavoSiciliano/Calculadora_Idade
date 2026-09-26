using System;

namespace Calculadora_Idade.Models
{
    internal struct Pessoa
    {
        public string Nome;
        public DateTime DataNascimento;

        public Pessoa(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}