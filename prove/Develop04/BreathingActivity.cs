using System.Diagnostics;
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
            new string[2] { "Breath In...", "Breath out..." })
    {
    }
    public void DisplayBreathingCycle(int parameter)
    {

    }
    public void RunActivity()
    {
        DisplayStartingMessage();
        SetDuration(int.Parse(Console.ReadLine()));
        Console.Clear();
        int promptIndex = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds /1000 < GetDuration())
        {
            DisplayPrompt(promptIndex);
            if (promptIndex == 0)
            {
                promptIndex = 1;
                DisplayAnimation(3, 25);
            }
            else
            {
                promptIndex = 0;
                DisplayAnimation(4, 25);
            }
        }
        DisplayEndingMessage();
    }
}