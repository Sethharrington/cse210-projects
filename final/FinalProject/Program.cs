using System;

class Program
{
    static void Main(string[] args)
    {
        TestApp app = new TestApp();

        int userChoice = -1;
        Test test = new Test();
        while (true)
        {
            userChoice = app.InputInt(1, 5, "Choose an option:\n"
                            + "1. Load Test.\n"
                            + "2. Apply Test.\n"
                            + "3. Get Results.\n"
                            + "4. Save.\n"
                            + "5. Quit.\n");
            switch (userChoice)
            {
                case 1:
                    test.LoadTest();
                    break;
                case 2:
                    test.ApplyTest();
                    break;
                case 3: break;
                case 4: break;
                case 5: return;
                default:
                    break;
            }
        }
    }
}