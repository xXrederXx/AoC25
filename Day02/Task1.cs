static class Task1
{
    public static void Execute()
    {
        string rangesInput = File.ReadAllLines("input.txt").First();
        string[][] ranges = rangesInput.Split(',').Select(x => x.Split('-')).ToArray();
        foreach (string[] range in ranges)
        {
            ComputeRange(range.First(), range.Last());
        }
    }   

    private static void ComputeRange(string start, string end)
    {
        
    }
}