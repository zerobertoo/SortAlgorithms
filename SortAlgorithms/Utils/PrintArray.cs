namespace SortAlgorithms.Utils;

public class PrintArray
{
    public static void Main(int[] array)
    {
        const int elementsPerLine = 10; // Número de elementos por linha
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
            if ((i + 1) % elementsPerLine == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}