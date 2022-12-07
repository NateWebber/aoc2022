public class D07 : Day
{
    static int DAY_NUM = 7; //TODO Change me when using this template
    static string[] inputLines = { };

    static Dictionary<string, Directory> allDirectories = new Dictionary<string, Directory>();
    static string currentDirectory = "/";
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
    * If I were writing this program again, I would probably make currentDictionary an instance of Dictionary, not a string
    * I thought using the string would be more useful for the sake of lookups but I don't think that was the case.
    * I also made the unfortunate assumption that directories would have entirely unique names, but luckily one I realized
    * this error it wasn't too difficult to fix by just naming directories their full path instead
    */
    private static void Solve()
    {
        allDirectories[currentDirectory] = new Directory(currentDirectory);
        foreach (string line in inputLines)
        {
            if (line[0] == '$')
                processCommand(line);
            else
                processDirInfo(line);
        }
        long total = 0;
        int smallestValidSize = int.MaxValue;
        int spaceToBeFreed = 30000000 - (70000000 - allDirectories["/"].Size); // calculate unused space, then figure out how much more we need to get to 30000000
        foreach (Directory dir in allDirectories.Values)
        {
            if (dir.Size <= 100000)
                total += dir.Size;

            if (dir.Size >= spaceToBeFreed && dir.Size < smallestValidSize)
                smallestValidSize = dir.Size;
        }
        Console.WriteLine($"Part 1: {total}");
        Console.WriteLine($"Part 2: {smallestValidSize}");
    }

    /*
    * This function is a little bit misleading just in the sense that we only actually
    * do anything if we see a "cd" command. An "ls" is just thrown out since we only
    * care about the actual output of such a command
    */
    private static void processCommand(string line)
    {
        string[] splitLine = line.Split(" ");
        if (splitLine[1].Equals("cd"))
        {
            switch (splitLine[2])
            {
                case "..":
                    if (!(currentDirectory.Equals("/")))
                        currentDirectory = allDirectories[currentDirectory].Parent.Name;
                    break;
                case "/":
                    currentDirectory = "/";
                    break;
                default:
                    // note this assumes we'll always ls before we cd into a new dir
                    // I got away with this assumption, but if I hadn't it would've broken if the next directory didn't exist yet
                    currentDirectory = currentDirectory + splitLine[2] + "/";
                    break;
            }
        }
    }

    private static void processDirInfo(string line)
    {
        string[] splitLine = line.Split(" ");
        if (splitLine[0].Equals("dir")) //process info about this dir
        {
            if (!(allDirectories.ContainsKey(splitLine[1]))) //if we've already seen this directory we shouldn't add it again
            {
                Directory newDir = new Directory(currentDirectory + splitLine[1] + "/");
                newDir.Parent = allDirectories[currentDirectory];
                allDirectories[currentDirectory + splitLine[1] + "/"] = newDir;
            }
        }
        else //process file info
        {
            string fileInfo = splitLine[0] + " " + splitLine[1];
            if (!(allDirectories[currentDirectory].Files.Contains(fileInfo)))
            {
                allDirectories[currentDirectory].Files.Add(fileInfo);
                allDirectories[currentDirectory].Size += int.Parse(splitLine[0]);
                Directory? parent = allDirectories[currentDirectory].Parent;
                while (parent != null) // make sure to perpetuate the size up the directory's ancestry
                {
                    parent.Size += int.Parse(splitLine[0]);
                    parent = parent.Parent;
                }
            }
        }
    }

    /*
    * It seemed easiest to just go ahead and write a little Directory class
    * I think this was the right call, since being able to store the size of 'all' directories
    * made Part 2 much easier
    */
    private class Directory
    {
        private string name;
        public string Name // coming from Java I'm a big fan of the convenience of these properties
        {
            get { return name; }
        }
        private int size;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        private List<string> files;

        public List<string> Files
        {
            get { return files; }
        }
        public void addFile(string newFile)
        {
            this.files.Add(newFile);
        }
        private List<Directory> subDirectories;
        public List<Directory> SubDirectories
        {
            get
            {
                return subDirectories;

            }
        }

        public void addSubDirectory(Directory newDir)
        {
            this.subDirectories.Add(newDir);
        }

        private Directory? parent;

        public Directory? Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public Directory(string n)
        {
            this.name = n;
            this.size = 0;
            this.subDirectories = new List<Directory>();
            this.files = new List<string>();
        }
    }

}