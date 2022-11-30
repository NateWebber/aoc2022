public class App
{
    public static void Main(string[] Args)
    {
        switch (int.Parse(Args[0]))
        {
            case 1:
                if (Args.Count() == 2)
                    D01.Run("inputs/" + Args[1]);
                else
                    D01.Run("inputs/01");
                break;
            default:
                Console.WriteLine($"Invalid day {Args[0]}");
                break;
        }
    }
}