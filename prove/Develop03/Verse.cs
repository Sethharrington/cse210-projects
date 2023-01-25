public class Verse
{
    private string _canonicalBook;
    private Random randomGenerator = new Random();
    private string _book;
    private int _chapter;
    private string _verseNumber;

    private string _verse;
    private string[] _wordsInVerse;
    private List<int> _indexHidedWords = new List<int>();
    public Verse()
    {
        _verse = "";
        _wordsInVerse = _verse.Split(" ");
    }
    public Verse(string canonicalBook, string book, int chapter, string verseNumber, string verse)
    {
        _canonicalBook = canonicalBook;
        _book = book;
        _chapter = chapter;
        _verseNumber = verseNumber;
        _verse = verse;

        _wordsInVerse = _verse.Split(" ");
    }
    public void HideWords()
    {
        for (int i = 0; i < 3 && IsKeepRunning(); i++)
        {
            int number = 0;
            if (_indexHidedWords.Count == 0)
            {
                HideWord(number);
            }
            else
            {
                number = RandomNumberExcludingRepeated();
                HideWord(number);
            }
        }
    }
    public void HideWord(int number)
    {
        _indexHidedWords.Add(number);
        char[] word = _wordsInVerse[number].ToCharArray();
        for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
        {
            word[letterIndex] = '_';
        }
        _wordsInVerse[number] = new string(word);
    }
    public void DisplayVerse()
    {
        Console.Write(GetReference());
        foreach (string word in _wordsInVerse)
        {
            Console.Write(word + " ");
        }
    }

    public string GetReference()
    {
        return ($"{_canonicalBook} - {_book} {_chapter}: {_verseNumber}");
    }

    public string GetVerse()
    {
        return $"{_canonicalBook},/{_book},/{_chapter},/{_verseNumber},/{_verse}";
    }
    private int RandomNumberExcludingRepeated()
    {
        int number = randomGenerator.Next(0, _wordsInVerse.Length);
        while (true)
        {
            if (!_indexHidedWords.Contains(number))
            {
                break;
            }
            else
            {
                number = randomGenerator.Next(0, _wordsInVerse.Length);
            }
        }
        return number;
    }
    public bool IsKeepRunning()
    {
        return (_indexHidedWords.Count < _wordsInVerse.Length);
    }
}