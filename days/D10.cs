public class D10 : Day
{
    static int DAY_NUM = 10;
    static string[] inputLines = { };

    static int registerValue = 1;
    static int clock = 0;
    static int signalSum = 0;
    static string CRTstring = "#";
    static int spritePos = 1;
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
        foreach (string line in inputLines)
        {
            if (line[0] == 'n') //noop
            {
                incrementClock();
            }
            else //addx
            {
                incrementClock();
                registerValue += int.Parse(line.Split(" ")[1]);
                spritePos = registerValue;
                incrementClock();

            }
        }


        Console.WriteLine($"Part 1: {signalSum}");
        //Console.WriteLine($"register: {registerValue}");
        drawOutput();
    }

    /*
    * Increment the clock and add to the signal sum if necessary
    * Also do display processing
    */
    private static void incrementClock()
    {
        clock++;
        if ((clock % 40) == spritePos || (clock % 40) == (spritePos - 1) || (clock % 40) == (spritePos + 1))
        {
            CRTstring += '#';
        }
        else
        {
            CRTstring += '.';
        }
        if ((clock - 19) % 40 == 0)
        {
            Console.WriteLine($"during cycle {clock + 1} register = {registerValue}");
            signalSum += (clock + 1) * registerValue;
        }
        
    }

    private static void drawOutput()
    {
        for (int i = 0; i < 240; i++)
        {
            if (i % 40 == 0)
                Console.WriteLine();
            Console.Write(CRTstring[i]);
        }
        Console.WriteLine();
        Console.WriteLine();
    }



}