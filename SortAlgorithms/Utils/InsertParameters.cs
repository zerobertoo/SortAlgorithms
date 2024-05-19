namespace SortAlgorithms.Utils
{
    public class InsertParameters
    {
        public static int[] Config()
        {
            Console.Clear();
            Console.WriteLine("Configuração do Array:");
            Console.WriteLine("----------------------");

            int arraySize = GetArraySize();
            int firstNum = 0;
            char option = GetGenerationOption();

            return GenerateArrays.GenerateArray(option, arraySize, firstNum);
        }

        private static int GetArraySize()
        {
            Console.WriteLine("\nQual será o tamanho do array?");
            if (!int.TryParse(Console.ReadLine(), out int arraySize) || arraySize <= 0)
            {
                Console.WriteLine("Tamanho inválido. Por favor, insira um valor numérico positivo.");
                return GetArraySize();
            }
            return arraySize;
        }

        private static char GetGenerationOption()
        {
            Console.WriteLine("\nComo será a geração dos números?");
            Console.WriteLine("  C = Crescente");
            Console.WriteLine("  D = Decrescente");
            Console.WriteLine("  A = Aleatório");

            string option = Console.ReadLine().ToUpper();
            if (option != "C" && option != "D" && option != "A")
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma das opções fornecidas.");
                return GetGenerationOption();
            }
            return option[0];
        }
    }
}