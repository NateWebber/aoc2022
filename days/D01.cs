using System.Collections.Generic;
public class D01
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
        List<int> elfTotals = new List<int>();
        int index = 0;
        foreach (string line in inputLines)
        {
            if (line.Equals(""))
            {
                index++;
            }
            else
            {
                if (elfTotals.Count() == index + 1)
                    elfTotals[index] = elfTotals[index] + int.Parse(line);
                else
                    elfTotals.Add(int.Parse(line));
            }
        }
        elfTotals.Sort();
        int totalsCount = elfTotals.Count();
        Console.WriteLine($"Part 1: {elfTotals[totalsCount - 1]}");
        Console.WriteLine($"Part 2: {elfTotals[totalsCount - 1] + elfTotals[totalsCount - 2] + elfTotals[totalsCount - 3]}");

    }
    private static void Part2()
    {
        //Console.WriteLine("Part 2 not yet implemented...");
    }

}