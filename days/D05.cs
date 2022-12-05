public class D05 : Day
{
    static int DAY_NUM = 5; //TODO Change me when using this template
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
        [M]     [B]             [N]
[T]     [H]     [V] [Q]         [H]
[Q]     [N]     [H] [W] [T]     [Q]
[V]     [P] [F] [Q] [P] [C]     [R]
[C]     [D] [T] [N] [N] [L] [S] [J]
[D] [V] [W] [R] [M] [G] [R] [N] [D]
[S] [F] [Q] [Q] [F] [F] [F] [Z] [S]
[N] [M] [F] [D] [R] [C] [W] [T] [M]
 1   2   3   4   5   6   7   8   9 

indexes of chars are 1 + 4n (i.e. 2, 6, 10, ..., 34) 
     */

    static List<Stack<char>> theStacks = new List<Stack<char>>();
    private static void Solve()
    {
        for (int i = 0; i < 9; i++)
            theStacks.Add(new Stack<char>());
        bool parsingInstructions = false;
        foreach (string line in inputLines)
        {
            if (line.Equals(""))
            {
                // lol?? how to reverse a stack in c#
                //https://stackoverflow.com/questions/3297717/does-stack-constructor-reverse-the-stack-when-being-initialized-from-other-one
                for (int i = 0; i < 9; i++)
                {
                    theStacks[i] = new Stack<char>(theStacks[i]);
                }
                parsingInstructions = true;
                continue;
            }
            if (!parsingInstructions)
            {
                readInitialLine(line);
            }
            else
            {
                //readInstructionLine(line);
                readInstructionLineP2(line);
            }
        }
        String answer = "";
        foreach (Stack<char> stack in theStacks)
        {
            answer += stack.Peek();
        }
        Console.WriteLine($"Part 1: {answer}");


    }
    private static void readInitialLine(string line)
    {
        if (line.Contains("1"))//dumb hack to skip the numbering of stacks in the input, i may regret this
        {
            return;
        }
        //Console.WriteLine($"parsing: {line}");
        for (int i = 1; i <= 33; i += 4)
        {
            //Console.WriteLine($"i see: {line[i]}");
            if (!(line[i] == ' '))
            {
                int stackIndex = (i - 1) / 4; //i = 1 + 4n
                theStacks[stackIndex].Push(line[i]);
            }
        }
    }

    private static void readInstructionLine(string line)
    {
        string[] lineSplit = line.Split(" ");
        int howMany = int.Parse(lineSplit[1]);
        int sourceStack = int.Parse(lineSplit[3]) - 1; //don't forget kids we index by 0
        int destStack = int.Parse(lineSplit[5]) - 1;

        for (int i = 0; i < howMany; i++)
        {
            theStacks[destStack].Push(theStacks[sourceStack].Pop());
        }
    }

    private static void readInstructionLineP2(string line)
    {
        string[] lineSplit = line.Split(" ");
        int howMany = int.Parse(lineSplit[1]);
        int sourceStack = int.Parse(lineSplit[3]) - 1;
        int destStack = int.Parse(lineSplit[5]) - 1;

        Stack<char> tempStack = new Stack<char>();
        for (int i = 0; i < howMany; i++)
        {
            tempStack.Push(theStacks[sourceStack].Pop());
        }
        while (!(tempStack.Count == 0)){
            theStacks[destStack].Push(tempStack.Pop());
        }
    }

}