using System;
/**
/References for the code: https://stackoverflow.com/questions/14877237/getting-all-file-names-from-a-folder-using-c-sharp
/       To extract files in a folder.
/
*/
class Program
{
    static void Main(string[] args)
    {
        Journal journal1 = new Journal();
        int choice = -1;
        while (choice != 5)
        {
            Console.WriteLine("\nWhat do you want to do with your journal?\n" +
                             "Insert a number:\n" +
                             "1. Write\n" +
                             "2. Display\n" +
                             "3. Load\n" +
                             "4. Save\n" +
                             "5. Quit\n"
                             );

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: //Write
                    journal1.UserEntry();
                    break;
                case 2: //Display
                    journal1.Display();
                    break;
                case 3: //Load
                    journal1.LoadJournal();
                    break;
                case 4: //Save
                    journal1.SaveJournal();
                    break;
                case 5: //Quit
                    Console.WriteLine("Thanks for using the journal app.");
                    break;
            }
        }
    }
}