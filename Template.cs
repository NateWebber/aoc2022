public class Template
{
    static int DAY_NUM = 0; //TODO Change me when using this template
    static string[]? inputLines = null;
    public static void Run(string inPath)
    {
        Console.WriteLine($"Day {DAY_NUM} selected!");
        inputLines = File.ReadAllLines(inPath);
        if (inputLines == null)
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