public class Question
{
    public int _questionNumber;
    public string _question;
    public bool _alert;
    public int _answer;
    public bool _negative;
    public List<string> _options = new List<string>();
    public Question(int questionNumber, string question, bool alert, bool negative, List<string> options)
    {
        _questionNumber = questionNumber;
        _question = question;
        _answer = -1;
        _alert = alert;
        _negative = negative;
        _options = options;
    }
    public void PrintQuestion()
    {
        int optionNumber = 1;
        Console.WriteLine($"{_questionNumber}. {_question}");
        foreach (var option in _options)
        {
            Console.WriteLine($"\t{optionNumber++}. {option}");
        }
        Console.Write("Choose an option: ");
    }

    public void SetAnswer()
    {
        int userValue = 0;        
        {
            try
            {
                userValue = int.Parse(Console.ReadLine());
                _answer = userValue;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Please enter a valid option.");
            }
        }

    }
}