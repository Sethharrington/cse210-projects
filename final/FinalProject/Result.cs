public class Result
{
    public string _item;
    public List<int> _sumQuestions;
    // public List<Scale> _scales { get; set; }
    public Result(string item, List<int> sumQuestions)
    {
        _item = item;
        _sumQuestions = sumQuestions;
    }
}