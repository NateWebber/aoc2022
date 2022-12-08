public class D08 : Day
{
    static int DAY_NUM = 8; //TODO Change me when using this template
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

    static int GRID_WIDTH, GRID_HEIGHT;
    private static void Solve()
    {

        GRID_HEIGHT = inputLines.Count();
        GRID_WIDTH = inputLines[0].Length;
        int outsideVisibleCount = 0;
        int highestScenicScore = 0;
        for (int x = 0; x < GRID_WIDTH; x++)
        {
            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                if (visibleFromOutside(x, y))
                {
                    outsideVisibleCount++;
                }
                highestScenicScore = int.Max(highestScenicScore, getScenicScore(x, y));
            }

        }
        Console.WriteLine($"Part 1: {outsideVisibleCount}");
        Console.WriteLine($"Part 2: {highestScenicScore}");
    }

    private static bool visibleFromOutside(int x, int y)
    {
        //Console.WriteLine($"Checking {x}, {y}");
        if (x == 0 || y == 0 || y == GRID_HEIGHT - 1 || x == GRID_WIDTH - 1)
            return true;
        int thisHeight = (int)Char.GetNumericValue(inputLines[y][x]);
        bool visibleLeft = true, visibleRight = true, visibleTop = true, visibleBottom = true;
        for (int i = x - 1; i >= 0; i--) //go left
        {
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[y][i]))
            {
                visibleLeft = false;
                break;
            }
        }
        for (int i = x + 1; i < GRID_WIDTH; i++) //go right
        {
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[y][i]))
            {
                visibleRight = false;
                break;
            }
        }
        for (int i = y - 1; i >= 0; i--) //go up
        {
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[i][x]))
            {
                visibleTop = false;
                break;
            }
        }
        for (int i = y + 1; i < GRID_HEIGHT; i++) //go down
        {
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[i][x]))
            {
                visibleBottom = false;
                break;
            }
        }
        /*Console.WriteLine($"right - {visibleRight}");
        Console.WriteLine($"left - {visibleLeft}");
        Console.WriteLine($"top - {visibleTop}");
        Console.WriteLine($"bottom - {visibleBottom}");*/
        return visibleLeft || visibleRight || visibleTop || visibleBottom;
    }

    private static int getScenicScore(int x, int y)
    {
        int thisHeight = (int)Char.GetNumericValue(inputLines[y][x]);
        int leftScore = 0, rightScore = 0, topScore = 0, bottomScore = 0;
        for (int i = x - 1; i >= 0; i--) //go left
        {
            leftScore++;
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[y][i]))
            {
                break;
            }
        }
        for (int i = x + 1; i < GRID_WIDTH; i++) //go right
        {
            rightScore++;
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[y][i]))
            {
                break;
            }
        }
        for (int i = y - 1; i >= 0; i--) //go up
        {
            topScore++;
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[i][x]))
            {
                break;
            }
        }
        for (int i = y + 1; i < GRID_HEIGHT; i++) //go down
        {
            bottomScore++;
            if (thisHeight <= (int)Char.GetNumericValue(inputLines[i][x]))
            {
                break;
            }
        }
        return leftScore * rightScore * topScore * bottomScore;
    }

}