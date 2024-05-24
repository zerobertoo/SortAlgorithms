using SortAlgorithms.Utils;
using System.Diagnostics;

namespace SortAlgorithms.Algorithms;

public class MergeSort
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
        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;

            // Move os elementos do array[0..i-1], que são maiores que a chave,
            // para uma posição à frente de sua posição atual
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }
}
