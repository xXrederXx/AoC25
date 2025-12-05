using System.Text.RegularExpressions;

class Task1
{
    private static int counter;
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
        for (int i = 9; i > 0; i--)
        {
            for (int j = 9; j > 0; j--)
            {
                Regex regex = new Regex($"{i}.*{j}", RegexOptions.Multiline);
                if (regex.IsMatch(item))
                {
                    counter += i * 10 + j;
                    return;
                }
            }
        }
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