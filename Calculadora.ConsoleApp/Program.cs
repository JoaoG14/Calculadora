using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static string[] historico = new string[100];
        static int historicoIndex = 0;

        static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("-- Calculadora Tabajara 2025 --");
            Console.WriteLine();
            Console.WriteLine("[ 1 ] Somar");
            Console.WriteLine("[ 2 ] Subtrair");
            Console.WriteLine("[ 3 ] Multiplicar");
            Console.WriteLine("[ 4 ] Dividir");
            Console.WriteLine("[ 5 ] Tabuada");
            Console.WriteLine("[ 6 ] Histórico de Operações");
            Console.WriteLine("[ 7 ] Sair do sistema");
            Console.Write("-> ");
        }

        static int ObterOpcao()
        {
            if (!int.TryParse(Console.ReadLine(), out int operacao) || operacao < 1 || operacao > 7)
            {
                Console.WriteLine("Por favor, digite uma opção válida!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return -1;
            }
            return operacao;
        }

        static void ProcessarOperacao(int operacao)
        {
            if (operacao >= 1 && operacao <= 4)
                RealizarCalculo(operacao);
            else if (operacao == 5)
                ExibirTabuada();
            else if (operacao == 6)
                ExibirHistorico();
        }

        static void RealizarCalculo(int operacao)
        {
            double primeiroNumero = ObterNumero("Digite o primeiro número: ");
            double segundoNumero = ObterNumero("Digite o segundo número: ");
            double resultado = 0;
            string operacaoTexto = "";

            switch (operacao)
            {
                case 1:
                    resultado = primeiroNumero + segundoNumero;
                    operacaoTexto = " + ";
                    break;
                case 2:
                    resultado = primeiroNumero - segundoNumero;
                    operacaoTexto = " - ";
                    break;
                case 3:
                    resultado = primeiroNumero * segundoNumero;
                    operacaoTexto = " * ";
                    break;
                case 4:
                    if (segundoNumero == 0)
                    {
                        Console.WriteLine("Não é possível dividir por zero.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    resultado = primeiroNumero / segundoNumero;
                    operacaoTexto = " / ";
                    break;
            }

            RegistrarHistorico(primeiroNumero, operacaoTexto, segundoNumero, resultado);
            Console.WriteLine($"O resultado é {resultado:F2}");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static double ObterNumero(string mensagem)
        {
            double numero;
            Console.Write(mensagem);
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out numero))
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
                Console.Write(mensagem);
            }
            return numero;
        }


        static void RegistrarHistorico(double primeiroNumero, string operacaoTexto, double segundoNumero, double resultado)
        {
            if (historicoIndex < historico.Length)
            {
                historico[historicoIndex] = $"{primeiroNumero}{operacaoTexto}{segundoNumero} = {resultado:F2}";
                historicoIndex++;
            }
        }

        static void ExibirTabuada()
        {
            int numeroTabuada = (int)ObterNumero("Digite um número: ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("          Tabuada ");
            Console.WriteLine("--------------------------------");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numeroTabuada} x {i} = {numeroTabuada * i}");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void ExibirHistorico()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("      Histórico de Operações");
            Console.WriteLine("--------------------------------");
            if (historicoIndex == 0)
            {
                Console.WriteLine("Nenhuma operação realizada ainda.");
            }
            else
            {
                for (int i = 0; i < historicoIndex; i++)
                {
                    Console.WriteLine(historico[i]);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                int operacao = ObterOpcao();

                if (operacao == 7)
                    break;

                ProcessarOperacao(operacao);
            }
        }
    }
}
