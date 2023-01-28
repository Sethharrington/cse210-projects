using System.Diagnostics;
public class ListingActivity : Activity
{
    private int _itemCounter;
    public ListingActivity()
    : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            new string[5]{
                            "Who are people that you appreciate?",
                            "What are personal strengths of yours?",
                            "Who are people that you have helped this week?",
                            "When have you felt the Holy Ghost this month?",
                            "Who are some of your personal heroes?"
                            })
    {
    }
    public void DisplayItemsAmount()
    {
        Console.WriteLine($"You listed {_itemCounter} items.");
    }
    public void RunActivity()
    {
        Random randomGenerator = new Random();
        Stopwatch stopwatch = new Stopwatch();

        DisplayStartingMessage();
        SetDuration(int.Parse(Console.ReadLine()));
        Console.Clear();

        int promptIndex = randomGenerator.Next(0, 5),
            animationNumber = randomGenerator.Next(1, 4);
        Console.WriteLine("\nList as many responses you can to the following promp:\n\n---");
        DisplayPrompt(promptIndex);
        Console.WriteLine("Get Ready");
        DisplayAnimation(1, 5);

        Console.WriteLine("\nYou may begin in:");
        CountDown(3);


        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds / 1000 < GetDuration())
        {
            Console.ReadLine();
            _itemCounter++;
        }
        DisplayItemsAmount();
        DisplayEndingMessage();
    }
}