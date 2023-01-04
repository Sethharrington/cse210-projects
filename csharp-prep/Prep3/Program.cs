using System;

class Program
{
    static void Main(string[] args)
    {   
        string continueGame = "yes";
        while (continueGame.ToLower() == "yes")
        {
            //Variables
            int attempts = 1;
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);
            int userNumber = -1;
            while (userNumber != number)
            {
                Console.Write("What is your guess? ");
                userNumber = int.Parse(Console.ReadLine());
                if (userNumber > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (userNumber < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    break;
                }
                attempts++;
            }
            Console.WriteLine( attempts > 1 ? $"You guessed it in {attempts} attepmts!" : "You made it at first!");
            Console.Write("Type \"yes\" to keep playing or anything else to stop the game: ");
            continueGame = Console.ReadLine();
        }
    }
}