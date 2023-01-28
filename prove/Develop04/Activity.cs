public class Activity
{
    private string _title;
    private string _description;
    private double _duration;
    private string[] _prompts;
    private int _lastAnimation;
    public Activity(string title, string description, string[] prompts)
    {
        _title = title;
        _description = description;
        _prompts = prompts;
    }
    public void DisplayStartingMessage()
    {
        Console.Write($"Welcome to the {_title}\n\n" +
                            $"{_description}\n\n" +
                            "How long, in seconds, would you like for your session? (seconds): "
        );
    }
    public void SetDuration(double duration)
    {
        _duration = duration;
    }
    public double GetDuration()
    {
        return _duration;
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Congratulations!\nNow you can enjoy a happier day!\nYou are amazing!");
    }

    public void DisplayAnimation(int animationNumber, int cycles)
    {
        string[] animationCharacters;
        switch (animationNumber)
        {
            case 1:
                animationCharacters = new string[] { "/", "-", "\\", "|" };
                break;
            case 2:
                animationCharacters = new string[] { "/", "\\" };
                break;
            case 3:
                animationCharacters = new string[] { "|" };
                break;
            case 4:
                animationCharacters = new string[] { "\b" };
                break;
            default:
                animationCharacters = new string[] { "-" };
                break;
        }
        if (animationNumber == 4)
        {
            switch (_lastAnimation)
            {
                case 2: Console.Write("/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\"); break;
                case 3: Console.Write("|||||||||||||||||||||||||"); break;
                default: Console.Write("-------------------------"); break;
            }

        }
        for (int i = 0; i < cycles; i++)
        {
            foreach (var character in animationCharacters)
            {
                if (animationNumber == 4)
                {
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                Console.Write(character);
                if (animationNumber == 1)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                Thread.Sleep(200);
            }
        }
        Console.WriteLine();
        _lastAnimation = animationNumber;
    }



    public void CountDown(int time)
    {
        for (int i = time; i > 0; i--)
        {
            Thread.Sleep(1000);
            Console.Write(i);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }

    public void DisplayPrompt(int promptIndex)
    {
        Console.WriteLine(_prompts[promptIndex]);
    }
}