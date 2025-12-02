using Common;
//TODO SOLVE THIS
public static class Task2
{
    private static int counter = 50;
    private static int numZeros = 0;

    public static void ComputeTask()
    {
        string[] lines = FileHelper.GetLines("input.txt");
        foreach (string line in lines)
        {
            Compute(line);
        }
        System.Console.WriteLine("Result: " + numZeros);
    }

    private static void Compute(string line)
    {
        int num = 0;
        bool counterStartZero = counter == 0;
        bool counterFlip = false;

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
            numZeros++;
            counterFlip = true;
        }

        while (counter < 00)
        {
            counter += 100;
            numZeros++;
            counterFlip = true;
        }

        if (counterStartZero && counterFlip)
            numZeros--;

        if (counter == 0 && !counterStartZero)
        {
            numZeros++;
        }
    }
}
