public class GoalsApp
{
    private string _name;
    private List<Goal> _goals = new List<Goal>();
    private int _points;
    public GoalsApp()
    {
        _points = 0;
    }
    public GoalsApp(int points, List<Goal> goalsList, string name)
    {
        _name = name;
        _goals = goalsList;
        _points = points;
    }
    public void DisplayPoint()
    {
        Console.WriteLine($"You have {_points} points.");
    }
    public int InputInt(int min, int max, string message)
    {
        Console.Write(message);
        int userInt;
        do
        {
            try
            {
                userInt = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please type a number.");
                userInt = max + 1;
            }
        } while (userInt > max || userInt < min);
        return userInt;
    }
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:\n");
        DisplayGoals();
        int goalIndex = InputInt(1, _goals.Count(), "Which goal did you accomplish? ");
        _points += _goals[goalIndex - 1].RecordEvent();
    }
    public int GetAmountOfGoals()
    {
        return _goals.Count();
    }
    public void DisplayGoals()
    {
        int numberOfGoal = 1;
        foreach (var goal in _goals)
        {
            Console.Write($"{numberOfGoal++}. ");
            goal.DisplayGoal();
            Console.WriteLine();
        }
    }

    public void NewGoal(int typeOfGoal, string name, string description, int points, int bonusPoints, int goalLimit, int timesCompleted, string lastEvent, bool completed)
    {
        switch (typeOfGoal)
        {
            case 1: _goals.Add(new SimpleGoal(name, description, points, completed, lastEvent)); break;
            case 2: _goals.Add(new EternalGoal(name, description, points, false, lastEvent)); break;
            case 3: _goals.Add(new CheckListGoal(name, description, points, bonusPoints, goalLimit, timesCompleted, lastEvent)); break;
        }
    }
    public string InputString(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
    public void SaveGoal()
    {
        if (_goals.Count > 0)
        {

            GetGoalFilename(1);
            string fileExtension = "";
            int userChoice = InputInt(1, 3, "\nWhich extension do you want to use? (Type the number Ex: 3)\n" +
                        "1. txt\n" +
                        "2. csv\n" +
                        "3. xlsx\n" +
                        "4. No extension");
            switch (userChoice)
            {
                case 1: fileExtension = ".txt"; break;
                case 2: fileExtension = ".csv"; break;
                case 3: fileExtension = ".xlsx"; break;
            }
            using (StreamWriter outputFile = new StreamWriter("./Goals/" + _name + fileExtension))
            {
                outputFile.WriteLine(_points);
                foreach (var goal in _goals) outputFile.WriteLine(goal.GetStringRepresentation());
            }
            Console.WriteLine($"Your Goal was saved as {_name}{fileExtension}");
        }
        else Console.WriteLine("To save a file you need to add at least 1 entry");

    }
    public void LoadGoal()
    {
        // string filename = GetGoalFilename();
        GetGoalFilename(0);
        if (_name != "")
        {
            _goals.Clear();
            string[] lines = System.IO.File.ReadAllLines("./Goals/" + _name);
            int numberLine = 0;
            foreach (string line in lines)
            {
                numberLine++;
                if (numberLine == 1)
                {
                    _points = int.Parse(line);
                    continue;
                }
                string[] parts = line.Split(";");
                switch (parts[0])
                {
                    case "SimpleGoal": NewGoal(1, parts[1], parts[2], int.Parse(parts[3]), 0, 0, 0, parts[5], bool.Parse(parts[4])); break;
                    case "EternalGoal": NewGoal(2, parts[1], parts[2], int.Parse(parts[3]), 0, 0, 0, parts[4], false); break;
                    case "CheckListGoal": NewGoal(3, parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), parts[7], int.Parse(parts[5]) <= int.Parse(parts[6])); break;
                }


            }
        }
    }
    public void GetGoalFilename(int saveNotLoad)
    {
        int chooseFile;
        Directory.CreateDirectory("Goals");
        DirectoryInfo directory = new DirectoryInfo("./Goals/");
        FileInfo[] files = directory.GetFiles("*");

        //Display the txt files as menu
        int countFiles = 1;

        Console.Write("Current files in the folder.\n");
        foreach (var file in files) Console.WriteLine($"{countFiles++}. {file.Name}");

        if (saveNotLoad == 1) //Save
        {
            Console.Write("Type a number to select an existing file or type any letter to create a new Goal.\n");
            try
            {
                do
                {
                    chooseFile = int.Parse(Console.ReadLine());
                } while (chooseFile < 1 && chooseFile > countFiles);
                if (chooseFile != 0) _name = Path.GetFileNameWithoutExtension(files[chooseFile - 1].Name);
            }

            catch (System.Exception)
            {
                Console.WriteLine($"Type the name of your Goal");
                _name = Console.ReadLine();
            }

        }

        else if (saveNotLoad == 0) //Load
        {
            if (files.Count() == 0) Console.WriteLine("Sorry, there is no files to upload, create a new Goal instead.");

            else
            {
                try
                {
                    do
                    {
                        chooseFile = int.Parse(Console.ReadLine());
                    } while (chooseFile < 1 && chooseFile > countFiles);
                    if (chooseFile != 0) _name = files[chooseFile - 1].Name;
                }
                catch
                {
                    Console.WriteLine($"No file was loaded\n");
                }
            }

        }
    }
}