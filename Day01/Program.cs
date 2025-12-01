using Common;

public class Program
{
    private static int counter = 50;

    public static void Main(string[] args)
    {
        string[] lines = FileHelper.GetLines("test.txt");
        foreach (string line in lines)
        {
            Compute(line);
        }
    }

    private static void Compute(string line)
    {
        int num = 0;
        for (int i = 1; i < line.Length; i++)
        {
            // Avoid Parse Int because i can :)
            num += (int)((line[i] - '0') * Math.Pow(10, line.Length - 1 - i));
        }

        switch (line[0])
        {
            case 'L':
                counter -= num;
                break;

            case 'R':
                counter += num;
                break;
        }

        while (counter > 99)
        {
            counter -= 100;
        }

        while (counter < 00)
        {
            counter += 100;
        }
    }
}
