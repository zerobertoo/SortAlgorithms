using SortAlgorithms.Utils;
using System.Diagnostics;

namespace SortAlgorithms.Algorithms;

public class InsertSort
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

        // Começa com um grande gap, depois reduz o gap
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            // Realiza a ordenação com gap
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }
                array[j] = temp;
            }
        }
    }
}