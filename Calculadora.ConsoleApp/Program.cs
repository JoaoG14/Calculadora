using System.Globalization;

namespace Calculadora.ConsoleApp;

internal class Program
{
    static string[] historico = new string[100];
    static int historicoIndex = 0;

    static void Main(string[] args)
    {
        while (true)
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

            int operacao = int.Parse(Console.ReadLine());

            if (operacao == 7)
            {
                break;
            }
            else if (operacao < 1 || operacao > 7)
            {
                Console.WriteLine("Por favor digite uma opção válida!!!");
                Console.WriteLine("Digite qualquer tecla para continuar... ");
                Console.ReadKey();
                continue;
            }
            else if (operacao >= 1 && operacao <= 4)
            {
                Console.Write("Digite o primeiro número: ");
                double primeironumero = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Digite o segundo número: ");
                double segundonumero = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                double resultado = 0;
                string operacaoTexto = "";

                if (operacao == 1)
                {
                    resultado = primeironumero + segundonumero;
                    operacaoTexto = " + ";
                }
                else if (operacao == 2)
                {
                    resultado = primeironumero - segundonumero;
                    operacaoTexto = " - ";
                }
                else if (operacao == 3)
                {
                    resultado = primeironumero * segundonumero;
                    operacaoTexto = " * ";
                }
                else if (operacao == 4)
                {
                    if (segundonumero == 0)
                    {
                        Console.WriteLine("Não é possível dividir um número por zero");
                        Console.WriteLine("Digite qualquer tecla para continuar...");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        resultado = primeironumero / segundonumero;
                        operacaoTexto = " / ";
                    }
                }

                string registro = $"{primeironumero}{operacaoTexto}{segundonumero} = {resultado.ToString("F2", CultureInfo.InvariantCulture)}";
                if (historicoIndex < 100)
                {
                    historico[historicoIndex] = registro;
                    historicoIndex++;
                }
                Console.WriteLine("O resultado é " + resultado.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else if (operacao == 5)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("          Tabuada ");
                Console.WriteLine("--------------------------------");
                Console.Write("Digite um número: ");
                int numeroTabuada = Convert.ToInt32(Console.ReadLine());

                for (int contador = 1; contador <= 10; contador++)
                {
                    int resultadoTabuada = numeroTabuada * contador;
                    Console.WriteLine($"{numeroTabuada} x {contador} = {resultadoTabuada}");
                }
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else if (operacao == 6)
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
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
