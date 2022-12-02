public class D02
{
    static int DAY_NUM = 2; //TODO Change me when using this template
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
        Solve();
        Console.WriteLine($"Day {DAY_NUM} completed!");
    }

    private static void Solve()
    {
        int partOneScore = 0;
        int partTwoScore = 0;
        foreach (string line in inputLines)
        {
            partOneScore += doRound(line[0], line[2]);
            partTwoScore += doRoundPart2(line[0], line[2]);
        }
        Console.WriteLine($"Part 1: {partOneScore}");
        Console.WriteLine($"Part 2: {partTwoScore}");
    }

    private static int doRound(char opponentChoice, char myChoice)
    {
        switch (opponentChoice)
        {
            case 'A':
                switch (myChoice)
                {
                    case 'X':
                        return 4;
                    case 'Y':
                        return 8;
                    case 'Z':
                        return 3;
                }
                break;
            case 'B':
                switch (myChoice)
                {
                    case 'X':
                        return 1;
                    case 'Y':
                        return 5;
                    case 'Z':
                        return 9;
                }
                break;
            case 'C':
                switch (myChoice)
                {
                    case 'X':
                        return 7;
                    case 'Y':
                        return 2;
                    case 'Z':
                        return 6;
                }
                break;
        }
        return 0;
    }

    private static int doRoundPart2(char opponentChoice, char requiredResult)
    {
        switch (requiredResult)
        {
            case 'X': //must lose
                switch (opponentChoice)
                {
                    case 'A':
                        return 3;
                    case 'B':
                        return 1;
                    case 'C':
                        return 2;
                }
                break;
            case 'Y': //must draw
                switch (opponentChoice)
                {
                    case 'A':
                        return 4;
                    case 'B':
                        return 5;
                    case 'C':
                        return 6;
                }
                break;
            case 'Z': //must win
                switch (opponentChoice)
                {
                    case 'A':
                        return 8;
                    case 'B':
                        return 9;
                    case 'C':
                        return 7;
                }
                break;
            default:
                return 0;
        }
        return 0;
    }
}