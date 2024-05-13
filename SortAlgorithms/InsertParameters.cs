namespace SortAlgorithms;

public  class InsertParameters
{
    public static int[] Config()
    {
        Console.Clear();
        Console.WriteLine("\nQual vai ser o tamanho do array?");
        if (!int.TryParse(Console.ReadLine(), out int arraySize) || arraySize <= 0)
        {
            Console.WriteLine("Tamanho inválido. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return Config();
        }

        Console.WriteLine("\nQual será o valor inicial? (O padrão é 0 ou 1)");
        if (!int.TryParse(Console.ReadLine(), out int firstNum))
        {
            Console.WriteLine("Valor inválido. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return Config();
        }

        Console.WriteLine("\nComo será a geração dos números? (C = Crescente; D = Decrescente; A = Aleatório)");
        string option = Console.ReadLine().ToUpper();
        if (option != "C" && option != "D" && option != "A")
        {
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            return Config();
        }

        return GenerateArrays.GenerateArray(option, arraySize, firstNum);
    }
}
