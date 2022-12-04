public class D04 : Day
{
    static int DAY_NUM = 4; //TODO Change me when using this template
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
        int sum = 0;
        int sumTwo = 0;
        foreach (string line in inputLines)
        {
            string[] ranges = line.Split(",");
            string[] rangeOneArr = ranges[0].Split("-");
            string[] rangeTwoArr = ranges[1].Split("-");
            (int, int) rangeOne = (int.Parse(rangeOneArr[0]), int.Parse(rangeOneArr[1]));
            (int, int) rangeTwo = (int.Parse(rangeTwoArr[0]), int.Parse(rangeTwoArr[1]));
            if (pairContainsOther(rangeOne, rangeTwo) == 1 || pairContainsOther(rangeOne, rangeTwo) == 2)
                sum++;
            if (pairsOverlap(rangeOne, rangeTwo))
                sumTwo++;
        }
        Console.WriteLine($"Part 1: {sum}");
        Console.WriteLine($"Part 2: {sumTwo}");
    }

    /* 0 if neither, 1 if first contains second, 2 if second contains first
    i wrote it with this distinguishment because i thought it might be relevant for part two
    i guessed wrong, oh well */
    private static int pairContainsOther((int, int) rangeOne, (int, int) rangeTwo)
    {
        if (rangeOne.Item1 <= rangeTwo.Item1 && rangeOne.Item2 >= rangeTwo.Item2)
        {
            return 1;
        }
        else if (rangeTwo.Item1 <= rangeOne.Item1 && rangeTwo.Item2 >= rangeOne.Item2)
        {
            return 2;
        }
        return 0;
    }

    /*
    * This works but admittedly feels a little lazy
    * It's probably way more expensive than it needs to be, but my main priority was finishing fast
    */
    private static bool pairsOverlap((int, int) rangeOne, (int, int) rangeTwo)
    {
        HashSet<int> fullRangeOne = new HashSet<int>();
        HashSet<int> fullRangeTwo = new HashSet<int>();
        for (int i = rangeOne.Item1; i <= rangeOne.Item2; i++)
        {
            fullRangeOne.Add(i);
        }
        for (int i = rangeTwo.Item1; i <= rangeTwo.Item2; i++)
        {
            fullRangeTwo.Add(i);
        }
        foreach (int i in fullRangeOne)
        {
            if (fullRangeTwo.Contains(i))
                return true;
        }
        foreach (int i in fullRangeTwo)
        {
            if (fullRangeOne.Contains(i))
                return true;
        }
        return false;

        // this code was a quick experiement, i think there may be something to be found here along this line of reasoning but i haven't fully fleshed it out
        /*if (rangeTwo.Item1 <= rangeOne.Item2 && rangeTwo.Item1 >= rangeOne.Item1)
            return true;
        if (rangeTwo.Item2 >= rangeOne.Item1 && rangeTwo.Item2 <= rangeOne.Item2)
            return true;
        return false;*/
    }

}