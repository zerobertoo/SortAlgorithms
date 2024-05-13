using System.Diagnostics;

namespace SortAlgorithms;

public class SelectionSort
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
                Console.WriteLine(string.Join(" | ", originalArray));

                Console.WriteLine("\nArray depois da ordenação:");
                Console.WriteLine(string.Join(" | ", array));
            }
            Console.WriteLine($"\nTempo de execução: {stopwatch.ElapsedMilliseconds}ms");

            Console.WriteLine("\nDeseja refazer? (S = Sim; N = Não)");
            repeat = Console.ReadLine().ToUpper();
        }
    }

    private static void SortArray(int[] array) {
        int n = array.Length;

        // Percorre o array
        for (int i = 0; i < n - 1; i++)
        {
            // Encontra o índice do menor elemento no array não ordenado
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Troca o menor elemento encontrado com o primeiro elemento não ordenado
            (array[i], array[minIndex]) = (array[minIndex], array[i]);
        }
    }
}