public class App
{
    public void runMain()
    {
        int userChoice;

        string userContinue = "";


        string canonicalBook = "";
        string book = "";
        int chapter;
        string versicleNumber;

        Console.WriteLine("Select a canonical book:");
        // scriptures.DisplayCanonicalBooks();
        Console.WriteLine(
                "1. Old Testament\n" +
                "2. New Testament\n" +
                "3. Book Of Mormon\n" +
                "4. Doctrine and Covenants\n" +
                "5. Pearl of Great Price"
        );
        userChoice = int.Parse(Console.ReadLine());
        switch (userChoice)
        {
            case 1:
                canonicalBook = "Old Testament";
                break;
            case 2:
                canonicalBook = "New Testament";
                break;
            case 3:
                canonicalBook = "Book Of Mormon";
                break;
            case 4:
                canonicalBook = "Doctrine and Covenants";
                break;
            case 5:
                canonicalBook = "Pearl of Great Price";
                break;
            default:
                break;
        }
        Scriptures scriptures = new Scriptures(canonicalBook);

        if (canonicalBook == "Doctrine and Covenants")
        {
            book = "Doctrine and Covenants";
            scriptures.DisplayBooks(canonicalBook);
            // Console.WriteLine("Select a section:");
            // chapter = int.Parse(Console.ReadLine());
            chapter = typeCorrectInt("Select a section:", scriptures.GetAmountBooks());
        }
        else
        {
            scriptures.DisplayBooks(canonicalBook);
            // Console.WriteLine("Select a book:");
            // userChoice = int.Parse(Console.ReadLine());
            userChoice = typeCorrectInt("Select a book: ", scriptures.GetAmountBooks());
            book = scriptures.GetBookName(userChoice - 1);


            Console.WriteLine($"Select a chapter? between 1 and {scriptures.GetLengthOfBook(userChoice - 1)}: ");
            chapter = int.Parse(Console.ReadLine());
        }
        Console.Write("You can select many verses by typen the first and after the last.\n" +
                        "Which is the first verse?: ");
        versicleNumber = Console.ReadLine();
        string userVerse = scriptures.GetVerseByReference(canonicalBook, book, chapter, versicleNumber);
        Verse versicle = new Verse(canonicalBook, book, chapter, versicleNumber, userVerse);

        do
        {
            if (userContinue == "")
            {
                Console.Clear();
                versicle.HideWords();
                versicle.DisplayVerse();
                Console.WriteLine();
            }
            else if (userContinue.ToLower() == "quit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please press the 'Enter' key to continue or type 'quit' to stop the program.");
            }
            userContinue = Console.ReadLine();
        } while (versicle.IsKeepRunning());
    }
    public int typeCorrectInt(string message, int maxValue)
    {
        int userInput = 0;
        while (userInput > maxValue || userInput < 1)
        {
            Console.Write(message);
            userInput = int.Parse(Console.ReadLine());
        }
        return userInput;
    }
}