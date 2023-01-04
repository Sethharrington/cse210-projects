using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter a percentage: ");
        string valueFromUser = Console.ReadLine();
        float percentage = float.Parse(valueFromUser);
        char grade = ' ';
        char sign = ' ';

        if(percentage >= 90)
        {
            grade = 'A';
        }
        else if(percentage >= 80)
        {
            grade = 'B';
        }
        else if(percentage >= 70)
        {
            grade = 'C';
        }
        else if(percentage >= 60)
        {
            grade = 'D';
        }
        else
        {
            grade = 'F';
        }
        //Sign
        float remainder = percentage % 10;
        if(remainder >= 7 && grade != 'A' && grade != 'F')
        {
            sign = '+';
        }
        else if(remainder <= 3 && grade != 'A' && grade != 'F')
        {
            sign = '-';
        }
        Console.WriteLine($"Your grade is: {grade}{sign}");
        if(percentage >= 70)
        {
            Console.WriteLine($"Congratulations! You've approved the course.");
        }
        else
        {
            Console.WriteLine($"Sorry, you didn't approve the course, you can try again.");
        }
    }
}