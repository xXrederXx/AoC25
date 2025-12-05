using System.Text.RegularExpressions;

class Task2
{
    private static long counter;
    public static void Execute()
    {
        string[] rangesInput = File.ReadAllLines("input.txt");
        foreach (string item in rangesInput)
        {
            CalculateForItem(item);
        }
        System.Console.WriteLine("Result: " + counter);
    }

    private static void CalculateForItem(string item)
    {
        char[] arr = item.ToCharArray();
        char[] firstNums = arr.Take(arr.Length - 12).ToArray();
        int idx = -1;
        
        for(int i = 9; i > 0; i--)
        {
            idx = firstNums.IndexOf(i.ToString()[0]);
            if(idx != -1)
            {
                break;
            }
        }
        arr = arr.Skip(idx).ToArray();
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr.Where(x => x != char.MaxValue).Count() == 12)
                break;

            char c1 = arr[i];
            if(i + 1 >= arr.Length) continue;
            char c2 = arr[i + 1];
            if (c1 <= c2)
            {
                arr[i] = char.MaxValue;
            }
        }

        long num = long.Parse(
            string.Join("", arr.Where(x => x != char.MaxValue).Take(12))
        );
        counter += num;
        System.Console.WriteLine($"{item} {num}");
    }

    private static int findHighestBumIdx(string str, int start)
    {
        for (int i = 9; i > 0; i--)
        {
            int idx = str.IndexOf(i.ToString(), start);
            if (idx != -1)
                return idx;
        }

        return -1;
    }
}