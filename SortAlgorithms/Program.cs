using SortAlgorithms.Algorithms;

while (true)
{
    Console.Clear();
    Console.WriteLine("Qual algoritmo você deseja utilizar?");
    Console.WriteLine("  Bubble Sort = 'BS'");
    Console.WriteLine("  Selection Sort = 'SS'");
    Console.WriteLine("  Insert Sort = 'SH'");
    Console.WriteLine("  Merge Sort = 'MS'");
    Console.WriteLine("  Quick Sort = 'QS'");
    Console.Write("Opção: ");
    string algorithm = Console.ReadLine().ToUpper();

    Action sortAction = algorithm switch
    {
        "BS" => BubbleSort.Main,
        "SS" => SelectionSort.Main,
        "IS" => InsertSort.Main,
        "MS" => MergeSort.Main,
        "QS" => QuickSort.Main,
        _ =>
        () =>
        {
            Console.WriteLine("Algoritmo não reconhecido. Por favor, escolha novamente.");
            Console.ReadLine();
        }
    };

    Console.WriteLine("\nExecutando o algoritmo...");
    try
    {
        sortAction();
        Console.WriteLine("\nAlgoritmo executado com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro ao executar o algoritmo: {ex.Message}");
    }

    Console.WriteLine("\nDeseja utilizar outro algoritmo? (Sim = S; Não = N)");
    string bypass = Console.ReadLine().ToUpper();
    if (bypass != "S")
    {
        break;
    }
}