public class Entry
{
    public string _date;
    public string _userText = "";
    public string _prompt = "";

    public Entry()
    {
        _date = $"{DateTime.Now}";
    }
    public List<string> _prompts = new List<string>();

    public void Display()
    {
        Console.WriteLine($"Date:{_date} - Prompt: {_prompt}\n{_userText}\n");
    }
    public string GetEntry()
    {
        return $"{_date},{_prompt},{_userText}";
    }
    public void NewEntry(string text, string prompt)
    {
        _userText = text;
        _prompt = prompt;
    }
}