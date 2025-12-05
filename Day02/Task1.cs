static class Task1
{
    private static ulong counter;
    public static void Execute()
    {
        string rangesInput = File.ReadAllLines("input.txt").First();
        string[][] ranges = rangesInput.Split(',').Select(x => x.Split('-')).ToArray();
        foreach (string[] range in ranges)
        {
            ComputeRanges(range.First(), range.Last());
        }
        System.Console.WriteLine(counter);
    }

    private static void ComputeRanges(string start, string end)
    {
        for (int i = start.Length; i <= end.Length; i++)
        {
            if (i % 2 == 0)
            {
                ComputeRange(i, ulong.Parse(start), ulong.Parse(end));
            }
        }
    }

    private static void ComputeRange(int length, ulong start, ulong end)
    {
        int halfLegth = length / 2;

        ulong exponent = (ulong)Math.Pow(10, halfLegth);
        ulong startNum = (ulong)Math.Pow(10, halfLegth - 1);
        ulong endNum = (ulong)Math.Pow(10, halfLegth) - 1;

        for (ulong i = startNum; i <= endNum; i++)
        {
            ulong num = i + i * exponent;
            if (num >= start && num <= end)
            {
                counter += num;
            }
        }
    }
}