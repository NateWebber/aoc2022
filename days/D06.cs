public class D06 : Day
{
    static int DAY_NUM = 6;
    static string[] inputLines = { };
    public void Run(string inPath)
    {
        Console.WriteLine($"Day {DAY_NUM} selected!");
        inputLines = File.ReadAllLines(inPath);
        if (inputLines.Count() == 0)
        {
            Console.WriteLine($"Error reading input from {inPath}, exiting...");
            return;
        }
        Solve();
        Console.WriteLine($"Day {DAY_NUM} completed!");
    }

    private static void Solve()
    {
        int partOneAnswer = 0;
        int partTwoAnswer = 0;
        string theLine = inputLines[0];
        for (int i = 3; i < theLine.Length; i++)
        {
            string lastFour = theLine.Substring(i - 3, 4);
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in lastFour)
            {
                chars.Add(c);
            }
            if (chars.Count == 4)
            {
                partOneAnswer = i + 1;
                break;
            }
        }
        for (int i = 13; i < theLine.Length; i++)
        {
            string lastFour = theLine.Substring(i - 13, 14);
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in lastFour)
            {
                chars.Add(c);
            }
            if (chars.Count == 14)
            {
                partTwoAnswer = i + 1;
                break;
            }
        }
        Console.WriteLine($"Part 1: {partOneAnswer}");
        Console.WriteLine($"Part 2: {partTwoAnswer}");
    }

}