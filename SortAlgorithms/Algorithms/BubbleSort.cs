using SortAlgorithms.Utils;
using System.Diagnostics;

namespace SortAlgorithms.Algorithms;

public class BubbleSort
{
    public static void Main()
    {
        string repeat = "S";
        while (repeat == "S")
        {
            int[] array = InsertParameters.Config();
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
                PrintArray.Main(originalArray);

                Console.WriteLine("\nArray depois da ordenação:");
                PrintArray.Main(array);
            }
            Console.WriteLine($"\nTempo de execução: {stopwatch.ElapsedMilliseconds}ms");

            Console.WriteLine("\nDeseja refazer? (S = Sim; N = Não)");
            repeat = Console.ReadLine().ToUpper();
        }
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