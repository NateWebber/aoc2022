public class D1
{
    static int DAY_NUM = 1; //TODO Change me from 0 when using this template
    static string[] inputLines = { };
    public static void Run(string inPath)
    {
        Console.WriteLine($"Day {DAY_NUM} selected!");
        inputLines = File.ReadAllLines(inPath);
        if (inputLines.Count() == 0)
        {
            Console.WriteLine($"Error reading input from {inPath}, exiting...");
            return;
        }
        Part1();
        Part2();
        Console.WriteLine($"Day {DAY_NUM} completed!");
    }

    private static void Part1()
    {
        Console.WriteLine("Part 1 not yet implemented...");
    }
    private static void Part2()
    {
        Console.WriteLine("Part 2 not yet implemented...");
    }

}