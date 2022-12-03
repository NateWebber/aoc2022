public class D03 : Day
{
    static int DAY_NUM = 3; //TODO Change me when using this template
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
    /*
    * This problem was pretty straight forward and I didn't try to get too fancy with it
    * Doing that tends to wind up going poorly for me
    */
    private static void Solve()
    {
        int prioritySum = 0;
        int badgeSum = 0;
        List<string> elfGroup = new List<string>();
        for (int i = 0; i < inputLines.Length; i++)
        {
            prioritySum += getRepeatedPriority(inputLines[i]); //get the part 1 value
            if (i > 0 && i % 3 == 0) //in hindsight i could've just seen if the list had 3 items but oh well
            {
                badgeSum += getBadgePriority(elfGroup);
                elfGroup = new List<string>();
                elfGroup.Add(inputLines[i]);
            }
            else
            {
                elfGroup.Add(inputLines[i]);
            }
        }
        badgeSum += getBadgePriority(elfGroup); //gotta get the last one
        Console.WriteLine($"Part 1: {prioritySum}");
        Console.WriteLine($"Part 2: {badgeSum}");
    }

    private static int getRepeatedPriority(string line)
    {
        //split the string in two
        int midpoint = (line.Length / 2);
        string firstHalf = line.Substring(0, midpoint);
        string secondHalf = line.Substring(midpoint);
        foreach (char c in firstHalf) //find the matching character between the halves
            if (secondHalf.Contains(c))
                return getCharPriority(c);
        Console.WriteLine("getRepeatedPriority didn't find matches"); //we shouldn't get here
        return 0;
    }

    private static int getBadgePriority(List<string> group)
    {
        foreach (char c in group[0])
            if (group[1].Contains(c) && group[2].Contains(c))
                return getCharPriority(c);
        Console.WriteLine("getBadgePriority didn't find a match"); //we also shouldn't get here
        return 0;
    }

    private static int getCharPriority(char c)
    {
        /*
        * ASCII values for uppercase letters are 65 (A) -> 90 (Z)
        * ASCII values for lowercase letters are 97 (a) -> 122 (z)
        * So we can figure out if it's upper/lowercase using those ranges,
        * and then subtract the right amount to make uppercase worth 27 -> 52, and lowercase worth 1 -> 26
        */
        if (c >= 65 && c <= 90) //UPPERCASE LETTER
        {
            return c - 38; //A = 27, B = 28, ...
        }
        else if (c >= 97 && c <= 122) //lowercase letter
        {
            return c - 96; //a = 1, b = 2, ...
        }
        else
        {
            Console.WriteLine("getCharPriority saw invalid char"); //yet again, we shouldn't get here
            return 0;
        }
    }

}