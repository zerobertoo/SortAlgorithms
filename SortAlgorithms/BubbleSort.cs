using System.Diagnostics;

namespace SortAlgorithms;

public class BubbleSort
{
    public static void Main()
    {
        string repeat = "S";
        while (repeat == "S")
        {
            int[] array = Parameters();
            int[] originalArray = array.ToArray(); // Cria uma cópia do array original
            string showArrays;

            Console.WriteLine("\nDeseja visualizar os arrays? (Sim = S; Não = N)");
            showArrays = Console.ReadLine().ToUpper();
            Console.Clear();

            Console.WriteLine("Ordenando...");

            // Inicia o temporizador
            Stopwatch stopwatch = Stopwatch.StartNew();
            SortArray(array);
            stopwatch.Stop();
            // Para o temporizador

            Console.Clear();

            if (showArrays == "S")
            {
                Console.WriteLine("\nArray antes da ordenação:");
                Console.WriteLine(string.Join(" | ", originalArray));

                Console.WriteLine("\nArray depois da ordenação:");
                Console.WriteLine(string.Join(" | ", array));
            }
            Console.WriteLine($"\nTempo de execução: {stopwatch.ElapsedMilliseconds}ms");

            Console.WriteLine("\nDeseja refazer? (S = Sim; N = Não)");
            repeat = Console.ReadLine().ToUpper();
        }
    }

    private static int[] Parameters()
    {
        Console.Clear();
        Console.WriteLine("\nQual vai ser o tamanho do array?");
        if (!int.TryParse(Console.ReadLine(), out int arraySize) || arraySize <= 0)
        {
            Console.WriteLine("Tamanho inválido. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return Parameters();
        }

        Console.WriteLine("\nQual será o valor inicial? (O padrão é 0 ou 1)");
        if (!int.TryParse(Console.ReadLine(), out int firstNum))
        {
            Console.WriteLine("Valor inválido. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return Parameters();
        }

        Console.WriteLine("\nComo será a geração dos números? (C = Crescente; D = Decrescente; A = Aleatório)");
        string option = Console.ReadLine().ToUpper();
        if (option != "C" && option != "D" && option != "A")
        {
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return Parameters();
        }

        return GenerateArrays.GenerateArray(option, arraySize, firstNum);
    }

    private static void SortArray(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                }
            }
        }
    }
}