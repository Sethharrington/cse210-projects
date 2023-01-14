using System.IO;
public class Journal
{
    public string _name = "";
    public List<Entry> _entries = new List<Entry>();
    string[] _prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
        };
    public void UserEntry()
    {
        string randomPrompt = RandomPrompt();
        Console.Write($"{randomPrompt}: ");

        string text = Console.ReadLine();

        NewEntry(randomPrompt, text);
    }
    public void NewEntry(string prompt, string userText, string date = "")
    {
        Entry newEntry = new Entry();

        newEntry._prompt = prompt;
        newEntry._userText = userText;
        if (date != "") newEntry._date = date;

        _entries.Add(newEntry);
    }
    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
    public string RandomPrompt()
    {
        Random randomGenerator = new Random();
        int promptLenght = _prompts.Length;
        int number = randomGenerator.Next(1, promptLenght);
        string randomPrompt = _prompts[number];
        return randomPrompt;
    }
    public void LoadJournal()
    {
        // string filename = GetJournalFilename();
        GetJournalFilename(0);
        if (_name != "")
        {
            _entries.Clear();
            string[] lines = System.IO.File.ReadAllLines("./Journal/" + _name);

            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                NewEntry(parts[1], parts[2], parts[0]);
            }
        }
    }

    public void SaveJournal()
    {
        if (_entries.Count > 0)
        {

            GetJournalFilename(1);
            Console.WriteLine("Which extension do you want to use? (Type the number Ex: 3)\n" +
                        "1. txt\n" +
                        "2. csv\n" +
                        "3. xlsx\n" +
                        "4. No extension");

            string fileExtension = Console.ReadLine();
            switch (fileExtension)
            {
                case "1":
                    fileExtension = ".txt";
                    break;
                case "2":
                    fileExtension = ".csv";
                    break;
                case "3":
                    fileExtension = ".xlsx";
                    break;
                default:
                    fileExtension = "";
                    break;
            }
            using (StreamWriter outputFile = new StreamWriter("./Journal/" + _name + fileExtension))
            {
                foreach (var entry in _entries)
                {
                    outputFile.WriteLine(entry.GetEntry());
                }
            }
            Console.WriteLine($"Your journal was saved as {_name}{fileExtension}");
        }
        else
        {
            Console.WriteLine("To save a file you need to add at least 1 entry");
        }
    }

    public void GetJournalFilename(int saveNotLoad)
    {
        int chooseFile;
        Directory.CreateDirectory("Journal");
        DirectoryInfo directory = new DirectoryInfo("./Journal/");
        FileInfo[] files = directory.GetFiles("*");

        //Display the txt files as menu
        int countFiles = 1;

        Console.Write("Current files in the folder.\n");
        foreach (var file in files)
        {
            Console.WriteLine($"{countFiles++}. {file.Name}");
        }

        if (saveNotLoad == 1) //Save
        {
            Console.Write("Type a number to select an existing file or type any letter to create a new journal.\n");
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
                Console.WriteLine($"Type the name of your journal");
                _name = Console.ReadLine();
            }

        }

        else if (saveNotLoad == 0) //Load
        {
            if (files.Count() == 0)
            {
                Console.WriteLine("Sorry, there is no files to upload, create a new journal instead.");
            }
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