using System.Globalization;

namespace Calculadora.ConsoleApp;

internal class Program
{
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
            Console.WriteLine("[ 6 ] Sair do sistema");
            Console.Write("->");

            int operacao = int.Parse(Console.ReadLine());

            if (operacao == 6)
            {
                break;
            }
            else if (operacao < 1 || operacao > 6)
            {
                Console.WriteLine("Por favor digite uma opção válida!!!");
                Console.WriteLine("Digite qualquer tecla para continuar... ");
                Console.ReadKey();
                continue;
            }
            else if (operacao >= 1 && operacao <= 4)
            {
                Console.WriteLine("Digite o primeiro número: ");
                double primeironumero = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Digite o segundo número: ");
                double segundonumero = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                double resultado = 0;

                if (operacao == 1)
                {
                    resultado = primeironumero + segundonumero;
                }
                else if (operacao == 2)
                {
                    resultado = primeironumero - segundonumero;
                }
                else if (operacao == 3)
                {
                    resultado = primeironumero * segundonumero;
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
                    }
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
        }
    }
}
