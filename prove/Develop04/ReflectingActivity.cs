using System.Diagnostics;
public class ReflectingActivity : Activity
{
    private string[] _reflectingMessages;
    public ReflectingActivity()
        : base("Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            new string[]{
                            "Why was this experience meaningful to you?",
                            "Have you ever done anything like this before?",
                            "How did you get started?",
                            "How did you feel when it was complete?",
                            "What made this time different than other times when you were not as successful?",
                            "What is your favorite thing about this experience?",
                            "What could you learn from this experience that applies to other situations?",
                            "What did you learn about yourself through this experience?",
                            "How can you keep this experience in mind in the future?"
            })
    {
        _reflectingMessages = new string[]{
                                "Think of a time when you stood up for someone else.",
                                "Think of a time when you did something really difficult.",
                                "Think of a time when you helped someone in need.",
                                "Think of a time when you did something truly selfless."
                                };
    }


    public void RunActivity()
    {
        Random randomGenerator = new Random();
        DisplayStartingMessage();
        SetDuration(int.Parse(Console.ReadLine()));
        Console.Clear();

        int promptIndex,
            reflectIndex,
            animationNumber;
        Stopwatch stopwatch = new Stopwatch();
        reflectIndex = randomGenerator.Next(0, 4);
        Console.WriteLine("\nConsider the following prompt:\n\n---"
                        + _reflectingMessages[reflectIndex]
                        + "---\n\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds / 1000 < GetDuration())
        {
            animationNumber = randomGenerator.Next(1, 4);
            promptIndex = randomGenerator.Next(0, 9);
            DisplayPrompt(promptIndex);
            DisplayAnimation(animationNumber, 25);
        }
        DisplayEndingMessage();
    }
}