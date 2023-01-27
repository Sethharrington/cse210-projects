using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Samuel Bennett","Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        
        MathAssignment math1 = new MathAssignment("Roberto Rodriguez", "Fraction", "7.3", "8-19");
        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList());

        WritingAssignment write1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(write1.GetSummary());
        Console.WriteLine(write1.GetWritingInformation());
    }
}