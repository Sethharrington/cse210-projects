public class Test
{
    private string _name;
    private List<string> _options = new List<string>();
    private List<Question> _questions = new List<Question>();
    private List<Result> _results = new List<Result>();
    public void LoadTest()
    {
        _name = Console.ReadLine();
        _questions.Clear();
        string[] lines = System.IO.File.ReadAllLines("./Tests/" + _name);
        foreach (string line in lines)
        {
            string[] parts = line.Split(";");
            switch (parts[0])
            {
                case "_options": _options.Add(parts[1]); break;
                case "_questions": _questions.Add(new Question(int.Parse(parts[1]), parts[2], bool.Parse(parts[3]), bool.Parse(parts[4]), _options)); break;
                case "_result":
                    List<int> sum = parts[2].Split(",").Select(s => int.Parse(s)).ToList();
                    _results.Add(new Result(parts[1], sum)); break;
            }
        }
    }

    public void ApplyTest()
    {
        foreach (var question in _questions)
        {
            question.PrintQuestion();
            question.SetAnswer();
        }
    }
}