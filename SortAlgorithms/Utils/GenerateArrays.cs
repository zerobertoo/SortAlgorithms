namespace SortAlgorithms.Utils;

public class GenerateArrays
{
    public static int[] GenerateArray(char option, int size, int firstNum)
    {
        switch (option)
        {
            case 'C':
                return Enumerable.Range(firstNum, size).ToArray();

            case 'D':
                int[] descendingArray = Enumerable.Range(firstNum, size).ToArray();
                for (int i = 0; i < size / 2; i++)
                {
                    (descendingArray[size - i - 1], descendingArray[i]) = (descendingArray[i], descendingArray[size - i - 1]);
                }
                return descendingArray;

            case 'A':
                Random rnd = new();
                return Enumerable.Range(firstNum, size).OrderBy(x => rnd.Next()).ToArray();

            default:
                throw new ArgumentException("Opção inválida", nameof(option));
        }
    }
}