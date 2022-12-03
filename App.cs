public class App
{
    public static void Main(string[] Args)
    {
        if (Args.Length == 0)
        {
            Console.WriteLine("Error: Please specify a day");
            return;
        }
        string dayString = Args[0];
        if (dayString.Length == 1) //account for single digit numbers
            dayString = "0" + dayString;

        //refelection is neat but I don't really know how to do it properly just yet
        Console.WriteLine($"trying to get type D{dayString}");
        Type? dayType = Type.GetType($"D{dayString}");
        Day? dayInstance = null;
        if (dayType != null)
            dayInstance = (Day)Activator.CreateInstance(dayType);
        if (dayInstance != null)
        {
            if (Args.Length == 2)
            {
                dayInstance.Run($"inputs/{Args[1]}");
            }
            else
            {
                dayInstance.Run($"inputs/{dayString}");
            }
        }



        /*switch (int.Parse(Args[0]))
        {
            case 1:
                if (Args.Count() == 2)
                    D01.Run("inputs/" + Args[1]);
                else
                    D01.Run("inputs/01");
                break;
            case 2:
                if (Args.Count() == 2)
                    D02.Run("inputs/" + Args[1]);
                else
                    D02.Run("inputs/02");
                break;
            case 3:
                if (Args.Count() == 2)
                    D03.Run("inputs/" + Args[1]);
                else
                    D03.Run("inputs/02");
                break;
            default:
                Console.WriteLine($"Invalid day {Args[0]}");
                break;
        }*/

    }

}