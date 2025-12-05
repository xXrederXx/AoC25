static class Task2
{
    private static ulong counter;
    public static void Execute()
    {
        string rangesstr = File.ReadAllLines("input.txt").First();
        string[][] ranges = rangesstr.Split(',').Select(x => x.Split('-')).ToArray();
        foreach (string[] range in ranges)
        {
            ComputeRanges(range.First(), range.Last());
        }
        System.Console.WriteLine("Result: " + counter);
    }

    private static void ComputeRanges(string start, string end)
    {
        ulong startNum = ulong.Parse(start);
        ulong endNum = ulong.Parse(end);

        ulong i = startNum;
        while (i <= endNum)
        {
            if (isInvalidId(i))
            {
                counter += i;
            }
            i++;
        }
    }
    private static bool isInvalidId(ulong id)
    {
        string idStr = id.ToString();
        int halfLength = idStr.Length / 2;

        for (int i = 1; i <= halfLength; i++)
        {
            string[] splited = splitEveryN(idStr, i);

            if (splited.Length <= 1) continue;

            string reference = splited[0];
            bool isOff = false;
            foreach (string str in splited)
            {
                if (str != reference)
                {
                    isOff = true;
                    continue;
                }
            }
            if(!isOff) return true;
        }
        return false;
    }
    private static string[] splitEveryN(string str, int n)
    {
        var result = new List<string>();

        // Validate strs
        if (string.IsNullOrEmpty(str) || str.Length % n != 0)
            return new string[0]; // Return empty list for null or empty string

        if (n <= 0)
            throw new ArgumentException("Chunk size must be greater than zero.", nameof(n));

        // Loop through the string in steps of n
        for (int i = 0; i < str.Length; i += n)
        {
            int length = Math.Min(n, str.Length - i);
            result.Add(str.Substring(i, length));
        }

        return result.ToArray();
    }
}