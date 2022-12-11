public class D09 : Day
{
    static int DAY_NUM = 9; //TODO Change me when using this template
    static string[] inputLines = { };

    static (int, int) headPos = (0, 0);
    static (int, int) tailPos = (0, 0);
    static List<(int, int)> tailPositions = new List<(int, int)>();
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

        tailPositions.Add((0, 0));

        foreach (string line in inputLines)
        {
            processLine(line);
        }
        Console.WriteLine($"Part 1: {tailPositions.Count}");
    }

    private static void processLine(string line)
    {
        for (int i = 0; i < (int)(Char.GetNumericValue(line[2])); i++)
        {
            switch (line[0])
            {
                case 'U':
                    headPos.Item2++;
                    break;
                case 'D':
                    headPos.Item2--;
                    break;
                case 'L':
                    headPos.Item1--;
                    break;
                case 'R':
                    headPos.Item1++;
                    break;
            }
            moveTail(); //i think it'll just be easier to move the tail each time
        }


    }

    private static void moveTail()
    {
        if (!tailNeedsMoving())
            return;

        //head is vertically up/down
        if (tailPos.Item1 == headPos.Item1)
        {
            if (tailPos.Item2 < headPos.Item2) //head is above
                tailPos.Item2++;
            else //head is below
                tailPos.Item2--;
        }

        //head is horizontally left/right
        else if (tailPos.Item2 == headPos.Item2)
        {
            if (tailPos.Item1 < headPos.Item1) //head is to the right
                tailPos.Item1++;
            else //head to the left
                tailPos.Item1--;
        }

        //diagonal logic
        else if (tailPos.Item1 < headPos.Item1 && tailPos.Item2 < headPos.Item2)//up and right
        {
            tailPos.Item1++;
            tailPos.Item2++;
        }
        else if (tailPos.Item1 < headPos.Item1 && tailPos.Item2 > headPos.Item2)//down and right
        {
            tailPos.Item1++;
            tailPos.Item2--;
        }
        else if (tailPos.Item1 > headPos.Item1 && tailPos.Item2 < headPos.Item2)//up and left
        {
            tailPos.Item1--;
            tailPos.Item2++;
        }
        else if (tailPos.Item1 > headPos.Item1 && tailPos.Item2 > headPos.Item2)//down and left
        {
            tailPos.Item1--;
            tailPos.Item2--;
        }
        if (!(tailPositions.Contains(tailPos))) //keep a record
            tailPositions.Add(tailPos);

    }

    //figure out if the tail is already in an ok position
    private static bool tailNeedsMoving()
    {
        if (tailPos.Equals(headPos)) //covers
            return false;
        if (tailPos.Equals((headPos.Item1 + 1, headPos.Item2))) //right
            return false;
        if (tailPos.Equals((headPos.Item1 - 1, headPos.Item2))) //left
            return false;
        if (tailPos.Equals((headPos.Item1, headPos.Item2 + 1))) //up
            return false;
        if (tailPos.Equals((headPos.Item1, headPos.Item2 - 1))) //down
            return false;
        if (tailPos.Equals((headPos.Item1 + 1, headPos.Item2 + 1))) //up right
            return false;
        if (tailPos.Equals((headPos.Item1 + 1, headPos.Item2 - 1))) //down right
            return false;
        if (tailPos.Equals((headPos.Item1 - 1, headPos.Item2 + 1))) //up left
            return false;
        if (tailPos.Equals((headPos.Item1 - 1, headPos.Item2 - 1))) //down left
            return false;

        return true;
    }

}