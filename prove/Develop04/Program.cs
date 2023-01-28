using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        while (true)
        {
            int animationNumber = randomGenerator.Next(1, 4);
            Console.Write("Menu Options:\n" +
                            "\t1. Start breathing activity\n" +
                            "\t2. Start reflecting activity\n" +
                            "\t3. Start listing activity\n" +
                            "\t4. Quit\n" +
                            "Select a choice from the menu: "
                            );
            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    BreathingActivity breath = new BreathingActivity();
                    // breath.DisplayStartingMessage();
                    // breath.SetDuration(int.Parse(Console.ReadLine()));
                    // breath.DisplayPrompt(0);
                    // breath.DisplayEndingMessage();
                    // breath.DisplayAnimation(animationNumber, 5);
                    breath.RunActivity();
                    break;
                case 2:
                    ReflectingActivity reflect = new ReflectingActivity();
                    // reflect.DisplayStartingMessage();
                    // reflect.SetDuration(int.Parse(Console.ReadLine()));
                    // reflect.DisplayEndingMessage();
                    // reflect.DisplayAnimation(animationNumber, 5);
                    reflect.RunActivity();
                    break;
                case 3:
                    ListingActivity list = new ListingActivity();
                    // list.DisplayStartingMessage();
                    // list.SetDuration(int.Parse(Console.ReadLine()));
                    // list.DisplayEndingMessage();
                    // list.DisplayAnimation(animationNumber, 5);
                    list.RunActivity();
                    break;
                case 4:
                    Console.WriteLine("Bye!\nThanks for participating.");
                    return;
                default:
                    break;
            }
            Console.WriteLine("Do you want to play again?\n");
        }

    }
}

/*
*Stretch to define multiple animations and choose them randomly depending on the activity.
*/