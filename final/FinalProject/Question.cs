public class Question
{
    private string _question;
    private List<string> _options;
    private int _answer;
    private bool _alert;
    public Question(string question, List<string> options, int answer, bool alert)
    {
        _question = question;
        _options = options;
        _answer = answer;
        _alert = alert;
    }
    public void PrintQuestion()
    {
        int optionNumber = 1;
        Console.WriteLine(_question);
        foreach (var option in _options)
        {
            Console.WriteLine($"{optionNumber++}. {option}");
        }
        Console.Write("Choose an option: ");
        SetAnswer();
    }
    public void SetAnswer()
    {
        int userValue = 0;
        do
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
        } while (userValue < 1 || userValue > _options.Count);

    }
}