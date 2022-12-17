public class D09 : Day
{
    static int DAY_NUM = 9; //TODO Change me when using this template
    static string[] inputLines = { };

    static (int, int) headPos = (0, 0);
    static (int, int) tailPos = (0, 0);
    static List<(int, int)> tailPositions = new List<(int, int)>();
    static List<(int, int)> longTailPositions = new List<(int, int)>();

    static (int, int)[] longRopePositions = {
        (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0)
    };

    /*
    * This code could absolutely be refactored to just run a rope of an arbitrary length
    * But I'm behind on AOC right now so I'll leave that as a "maybe do" for the future
    * and just roll with the messy code for now
    */
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
        longTailPositions.Add((0, 0));

        foreach (string line in inputLines)
        {
            processLine(line);
        }
        Console.WriteLine($"Part 1: {tailPositions.Count}");
        Console.WriteLine($"Part 2: {longTailPositions.Count}");
    }

    private static void processLine(string line)
    {
        int repeat = int.Parse(line.Split(" ")[1]);
        for (int i = 0; i < repeat; i++)
        {
            switch (line[0])
            {
                case 'U':
                    headPos.Item2++;
                    longRopePositions[0].Item2++;
                    break;
                case 'D':
                    headPos.Item2--;
                    longRopePositions[0].Item2--;
                    break;
                case 'L':
                    headPos.Item1--;
                    longRopePositions[0].Item1--;
                    break;
                case 'R':
                    headPos.Item1++;
                    longRopePositions[0].Item1++;
                    break;
            }
            moveTail(); //i think it'll just be easier to move the tail each time
            moveLongRope();
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

    private static void moveLongRope()
    {
        for (int i = 1; i <= 9; i++)
            moveSegment(i);
        if (!(longTailPositions.Contains(longRopePositions[9]))) //keep a record
            longTailPositions.Add(longRopePositions[9]);
    }

    private static void moveSegment(int segmentIndex)
    {
        if (!segmentNeedsMoving(segmentIndex))
            return;

        (int, int) thisSegment = longRopePositions[segmentIndex];
        (int, int) nextSegment = longRopePositions[segmentIndex - 1];
        //nextSegment is vertically up/down
        if (thisSegment.Item1 == nextSegment.Item1)
        {
            if (thisSegment.Item2 < nextSegment.Item2) //nextSegment is above
                thisSegment.Item2++;
            else //nextSegment is below
                thisSegment.Item2--;
        }

        //nextSegment is horizontally left/right
        else if (thisSegment.Item2 == nextSegment.Item2)
        {
            if (thisSegment.Item1 < nextSegment.Item1) //nextSegment is to the right
                thisSegment.Item1++;
            else //nextSegment to the left
                thisSegment.Item1--;
        }

        //diagonal logic
        else if (thisSegment.Item1 < nextSegment.Item1 && thisSegment.Item2 < nextSegment.Item2)//up and right
        {
            thisSegment.Item1++;
            thisSegment.Item2++;
        }
        else if (thisSegment.Item1 < nextSegment.Item1 && thisSegment.Item2 > nextSegment.Item2)//down and right
        {
            thisSegment.Item1++;
            thisSegment.Item2--;
        }
        else if (thisSegment.Item1 > nextSegment.Item1 && thisSegment.Item2 < nextSegment.Item2)//up and left
        {
            thisSegment.Item1--;
            thisSegment.Item2++;
        }
        else if (thisSegment.Item1 > nextSegment.Item1 && thisSegment.Item2 > nextSegment.Item2)//down and left
        {
            thisSegment.Item1--;
            thisSegment.Item2--;
        }
        longRopePositions[segmentIndex] = thisSegment;
    }

    private static bool segmentNeedsMoving(int segmentIndex)
    {
        (int, int) thisSegment = longRopePositions[segmentIndex];
        (int, int) nextSegment = longRopePositions[segmentIndex - 1];
        if (thisSegment.Equals(nextSegment)) //covers
            return false;
        if (thisSegment.Equals((nextSegment.Item1 + 1, nextSegment.Item2))) //right
            return false;
        if (thisSegment.Equals((nextSegment.Item1 - 1, nextSegment.Item2))) //left
            return false;
        if (thisSegment.Equals((nextSegment.Item1, nextSegment.Item2 + 1))) //up
            return false;
        if (thisSegment.Equals((nextSegment.Item1, nextSegment.Item2 - 1))) //down
            return false;
        if (thisSegment.Equals((nextSegment.Item1 + 1, nextSegment.Item2 + 1))) //up right
            return false;
        if (thisSegment.Equals((nextSegment.Item1 + 1, nextSegment.Item2 - 1))) //down right
            return false;
        if (thisSegment.Equals((nextSegment.Item1 - 1, nextSegment.Item2 + 1))) //up left
            return false;
        if (thisSegment.Equals((nextSegment.Item1 - 1, nextSegment.Item2 - 1))) //down left
            return false;

        //Console.WriteLine($"segment {segmentIndex + 1} needs to move");
        return true;
    }

}