namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora Tabajara 2025");
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("S - Sair");
            Console.WriteLine("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            int resultado = 0;

            if (opcao.ToUpper() == "S")
            {
                return;
            }


            Console.WriteLine("Digite o primeiro numero:");
            int primeiroNumero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o segundo numero: ");
            int segundoNumero = Convert.ToInt32(Console.ReadLine());

            if (opcao == "1") {

                resultado = primeiroNumero + segundoNumero;

            } else if (opcao == "2")
            {

                resultado = primeiroNumero - segundoNumero;

            }

            Console.WriteLine(resultado);

            


            Console.ReadLine();
        }
    }
}
