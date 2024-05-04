using SortAlgorithms;

while (true)
{
    Console.Clear();
    Console.WriteLine("Qual algoritmo você deseja utilizar? (Bubble Sort = 'BS')");
    string algorithm = Console.ReadLine().ToUpper();

    switch (algorithm)
    {
        case "BS":
            try
            {
                BubbleSort.Main();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao executar o Bubble Sort: {ex.Message}");
            }
            break;

        default:
            Console.WriteLine("Algoritmo não reconhecido. Por favor, escolha novamente.");
            break;
    }

    Console.Clear();
    Console.WriteLine("\nDeseja utilizar outro algoritmo? (Sim = S; Não = N)");
    string bypass = Console.ReadLine().ToUpper();
    if (bypass != "S")
    {
        break;
    }
}