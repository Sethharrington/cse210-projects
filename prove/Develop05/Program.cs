using System;
/*
* References
* Get the name of the class: https://stackoverflow.com/questions/2113069/c-sharp-getting-its-own-class-name
* Stretch: Record las event for a goal
* Display the current goal lists saved.
*
*/

class Program
{
    static void Main(string[] args)
    {
        GoalsApp goalApp = new GoalsApp();
        while (true)
        {
            goalApp.DisplayPoint();

            int menuChoice = goalApp.InputInt(1, 6, "Menu Options:\n" +
                                "\t1. Create New Goal\n" +
                                "\t2. List Goals\n" +
                                "\t3. Save Goals\n" +
                                "\t4. Load Goals\n" +
                                "\t5. Record Event\n" +
                                "\t6. Quit\n" +
                                "Select a choice from the menu: ");
            switch (menuChoice)
            {
                case 1:
                    int typeOfGoal = goalApp.InputInt(1, 4, "The types of Goals are:\n" +
                                "\t1. Simple Goal\n" +
                                "\t2. Eternal Goal\n" +
                                "\t3. Checklist Goal\n" +
                                "Which type of goal would you like to create? "
                                );
                    string goalName = goalApp.InputString("What is the name of your goal? ");
                    string goalDescription = goalApp.InputString("What is a short description of it? ");
                    int goalPoint = goalApp.InputInt(1, 1000000, "What is the amount of points associated with this goal? ");
                    int bonusPoints = 0;
                    int goalLimit = 0;
                    int timesCompleted = 0;
                    if (typeOfGoal == 3)
                    {
                        goalLimit = goalApp.InputInt(1, 1000000, "How many times does this goal need to be accomplished for a bonus? ");
                        bonusPoints = goalApp.InputInt(1, 1000000, "What is the bonus for accomplishing it that many times? ");
                    }
                    
                    goalApp.NewGoal(typeOfGoal, goalName, goalDescription, goalPoint, bonusPoints, goalLimit, timesCompleted, "",false);
                    break;
                case 2: goalApp.DisplayGoals(); break;
                case 3: goalApp.SaveGoal(); break;
                case 4: goalApp.LoadGoal(); break;
                case 5: goalApp.RecordEvent(); break;
                case 6: Console.WriteLine("Keep up the good work!!!"); return;
            }
        }
    }
}