using SortAlgorithms.Utils;
using System.Diagnostics;

namespace SortAlgorithms.Algorithms;

public class QuickSort
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
            SortArray(array, 0, array.Length - 1);
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

    private static void SortArray(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Encontra o índice de partição
            int pi = Partition(array, low, high);

            // Ordena os elementos antes e depois da partição
            SortArray(array, low, pi - 1);
            SortArray(array, pi + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high]; // Seleciona o último elemento como pivô
        int i = (low - 1); // Índice do menor elemento

        for (int j = low; j < high; j++)
        {
            // Se o elemento atual é menor ou igual ao pivô
            if (array[j] <= pivot)
            {
                i++;

                // Troca array[i] e array[j]
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        // Troca array[i+1] e array[high] (ou pivô)
        (array[high], array[i + 1]) = (array[i + 1], array[high]);
        return i + 1;
    }
}