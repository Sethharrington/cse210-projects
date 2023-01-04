using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> userNumbers = new List<int>();
        int nextNumber;
        do
        {
            Console.Write("Enter number: ");
            nextNumber = int.Parse(Console.ReadLine());
            if (nextNumber != 0) userNumbers.Add(nextNumber);
        } while (nextNumber != 0);

        Console.WriteLine($"The sum is: {userNumbers.Sum()}");
        Console.WriteLine($"The average is: {userNumbers.Average()}");
        Console.WriteLine($"The largest number is: {userNumbers.Max()}");
        Console.WriteLine($"The sorted list is:");
        userNumbers.Sort();
        foreach (int number in userNumbers) Console.WriteLine(number);
    }
}