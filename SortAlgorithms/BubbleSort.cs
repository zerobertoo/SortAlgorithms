using System.Diagnostics;

namespace SortAlgorithms;

public class BubbleSort
{
    private static bool sortingComplete = false;
    public static void Main()
    {
        string repeat = "S";
        while (repeat == "S")
        {
            int[] array = GenerateArray();
            int[] originalArray = array.ToArray(); // Cria uma cópia do array original
            string showArrays;

            Console.WriteLine("\nDeseja visualizar os arrays? (Sim = S; Não = N)");
            showArrays = Console.ReadLine().ToUpper();
            Console.Clear();

            Console.WriteLine("Ordenando...");
            sortingComplete = false;
            Thread loadingThread = new(() => ShowLoading());
            loadingThread.Start();

            // Inicia o temporizador
            Stopwatch stopwatch = Stopwatch.StartNew();
            SortArray(array);
            stopwatch.Stop();
            // Para o temporizador

            sortingComplete = true;
            loadingThread.Join();
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

    private static int[] GenerateArray()
    {
        Console.Clear();
        Console.WriteLine("\nQual vai ser o tamanho do array?");
        if (!int.TryParse(Console.ReadLine(), out int arraySize) || arraySize <= 0)
        {
            Console.WriteLine("Tamanho inválido. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return GenerateArray();
        }

        Console.WriteLine("\nQual será o valor inicial? (O padrão é 0 ou 1)");
        if (!int.TryParse(Console.ReadLine(), out int firstNum))
        {
            Console.WriteLine("Valor inválido. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return GenerateArray();
        }

        Console.WriteLine("\nComo será a geração dos números? (C = Crescente; D = Decrescente; A = Aleatório)");
        string option = Console.ReadLine().ToUpper();
        if (option != "C" && option != "D" && option != "A")
        {
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return GenerateArray();
        }

        return GenerateArray(option, arraySize, firstNum);
    }

    private static int[] GenerateArray(string option, int size, int firstNum)
    {
        switch (option)
        {
            case "C":
                return Enumerable.Range(firstNum, size).ToArray();

            case "D":
                int[] descendingArray = Enumerable.Range(firstNum, size).ToArray();
                for (int i = 0; i < size / 2; i++)
                {
                    (descendingArray[size - i - 1], descendingArray[i]) = (descendingArray[i], descendingArray[size - i - 1]);
                }
                return descendingArray;

            case "A":
                Random rnd = new Random();
                return Enumerable.Range(firstNum, size).OrderBy(x => rnd.Next()).ToArray();

            default:
                throw new ArgumentException("Opção inválida", nameof(option));
        }
    }

    private static void ShowLoading()
    {
        string[] loadingSymbols = ["|", "/", "-", "\\"];
        int index = 0;
        while (!sortingComplete)
        {
            Console.Write($"\r{loadingSymbols[index]}");
            index = (index + 1) % loadingSymbols.Length;
            Thread.Sleep(100); // Aguarda 100ms antes de exibir o próximo símbolo
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