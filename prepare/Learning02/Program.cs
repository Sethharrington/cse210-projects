using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company="Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        job1.Display();

        Job job2 = new Job();
        job2._company="Apple";
        job2._jobTitle = "Operation Engineer";
        job2._startYear = 2015;
        job2._endYear = 2019;

        job2.Display();

        Resume resume1 = new Resume();
        resume1._name="Seth Harrington";

        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        
        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);

        resume1.Display();
    }
}