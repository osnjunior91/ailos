using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria 
    {
        public int Numero { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            Numero = numero;
            Titular = titular;
            Saldo = depositoInicial;
        }

        public void Deposito(double valor)
        {
            if (valor <= 0)
            {
                throw new ValorInvalidoException("O valor do depósito deve ser maior que zero.");
            }

            Saldo += valor;
        }

        public void Saque(double valor)
        {
            if (valor <= 0)
            {
                throw new ValorInvalidoException("O valor do saque deve ser maior que zero.");
            }

            Saldo -= (valor + 3.50);
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo.ToString("N2")}";
        }

        public class ValorInvalidoException : Exception
        {
            public ValorInvalidoException(string message) : base(message) { }
        }

    }
}
