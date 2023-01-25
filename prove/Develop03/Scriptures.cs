public class Scriptures
{
    private List<Verse> _scriptures = new List<Verse>();
    private List<(string, int)> _lengthOfBooks;

    public Scriptures(string canonicalBookName)
    {
        LoadBooks(canonicalBookName);
        LoadVerses(canonicalBookName);
    }
    public string GetBookName(int userBook)
    {
        return _lengthOfBooks[userBook].Item1;
    }
    public void LoadBooks(string canonicalBookName)
    {
        switch (canonicalBookName)
        {
            case "Old Testament":
                _lengthOfBooks = new List<(string nameOfBook, int numberOfChapters)>{
                    ("Genesis", 50),
                    ("Exodus", 40),
                    ("Leviticus", 27),
                    ("Numbers", 36),
                    ("Deuteronomy", 34),
                    ("Joshua", 24),
                    ("Judges", 21),
                    ("Ruth", 4),
                    ("1 Samuel", 31),
                    ("2 Samuel", 24),
                    ("1 Kings", 22),
                    ("2 Kings", 25),
                    ("1 Chronicles", 29),
                    ("2 Chronicles", 36),
                    ("Ezra", 10),
                    ("Nehemiah", 13),
                    ("Esther", 10),
                    ("Job", 42),
                    ("Psalms", 150),
                    ("Proverbs", 31),
                    ("Ecclesiastes", 12),
                    ("Song of Solomon", 8),
                    ("Isaiah", 66),
                    ("Jeremiah", 52),
                    ("Lamentations", 5),
                    ("Ezekiel", 48),
                    ("Daniel", 12),
                    ("Hosea", 14),
                    ("Joel", 3),
                    ("Amos", 9),
                    ("Obadiah", 1),
                    ("Jonah", 4),
                    ("Micah", 7),
                    ("Nahum", 3),
                    ("Habakkuk", 3),
                    ("Zephaniah", 3),
                    ("Haggai", 2),
                    ("Zechariah", 14),
                    ("Malachi", 4)
                };
                break;

            case "New Testament":
                _lengthOfBooks = new List<(string nameOfBook, int numberOfChapters)>{
                    ("Matthew", 28),
                    ("Mark", 16),
                    ("Luke", 24),
                    ("John", 21),
                    ("Acts", 28),
                    ("Romans", 16),
                    ("1 Corinthians", 16),
                    ("2 Corinthians", 13),
                    ("Galatians", 6),
                    ("Ephesians", 6),
                    ("Philippians", 4),
                    ("Colossians", 4),
                    ("1 Thessalonians", 5),
                    ("2 Thessalonians", 3),
                    ("1 Timothy", 6),
                    ("2 Timothy", 4),
                    ("Titus", 3),
                    ("Philemon", 1),
                    ("Hebrews", 13),
                    ("James", 5),
                    ("1 Peter", 5),
                    ("2 Peter", 3),
                    ("1 John", 5),
                    ("2 John", 1),
                    ("3 John", 1),
                    ("Jude", 1),
                    ("Revelation", 22)
                };
                break;

            case "Book Of Mormon":
                _lengthOfBooks = new List<(string nameOfBook, int numberOfChapters)>{
                    ("1 Nephi", 22),
                    ("2 Nephi", 33),
                    ("Jacob", 7),
                    ("Enos", 1),
                    ("Jarom", 1),
                    ("Omni", 1),
                    ("Words of Mormon", 1),
                    ("Mosiah", 29),
                    ("Alma", 63),
                    ("Helaman", 16),
                    ("3 Nephi", 30),
                    ("4 Nephi", 1),
                    ("Mormon", 9),
                    ("Ether", 15),
                    ("Moroni", 10)
                };
                break;
            case "Doctrine and Covenants":
                _lengthOfBooks = new List<(string nameOfBook, int numberOfChapters)>{
                    ("Doctrine and Covenants", 138),
                };
                break;
            case "Pearl of Great Price":
                _lengthOfBooks = new List<(string nameOfBook, int numberOfChapters)>{
                    ("Moses", 8),
                    ("Abraham", 5),
                    ("Joseph Smith--Matthew", 1),
                    ("Joseph Smith--History", 1),
                    ("Articles of Faith", 1)
                };
                break;
            default:
                break;
        }
    }
    public int GetAmountBooks()
    {
        return _lengthOfBooks.Count();
    }
    public void NewVerse(string canonicalBook, string book, int chapter, string verseNumber, string verse)
    {
        Verse newVerse = new Verse(canonicalBook, book, chapter, verseNumber, verse);
        _scriptures.Add(newVerse);
    }

    public int GetLengthOfBook(int userBook)
    {
        return _lengthOfBooks[userBook].Item2;
    }
    public void DisplayCanonicalBooks()
    {
        Console.WriteLine(
                "1. Old Testament\n" +
                "2. New Testament\n" +
                "3. Book Of Mormon\n" +
                "4. Doctrine and Covenants\n" +
                "5. Pearl of Great Price"
        );
    }
    public void LoadVerses(string canonicalBookName)
    {
        string[] lines = System.IO.File.ReadAllLines("./Main/scriptures.txt");
        foreach (string line in lines)
        {
            // canonicalBook, book, chapter, verseNumber, verse
            string[] parts = line.Split(",/");
            if (canonicalBookName == parts[0])
            {
                NewVerse(parts[0], parts[1], int.Parse(parts[2]), parts[3], parts[4]);
            }
        }
    }
    public void DisplayBooks(string canonicalBook)
    {
        int count = 1;
        foreach (var tupleBook in _lengthOfBooks)
        {
            Console.WriteLine($"{count}. {tupleBook.Item1}");
            count++;
        }
    }
    public string GetVerseByReference(string canonicalBook, string book, int chapter, string verseNumber)
    {

        string verseText = "";
        int startVerse;
        int endVerse = 0;
        if (verseNumber.Contains('-'))
        {
            startVerse = int.Parse(verseNumber.Split("-")[0]);
            endVerse = int.Parse(verseNumber.Split("-")[1]);
        }
        else
        {
            startVerse = int.Parse(verseNumber);
        }
        foreach (var verse in _scriptures)
        {
            string[] verseReference = verse.GetVerse().Split(",/");
            if (verseReference[0] == canonicalBook)
                if (verseReference[1] == book)
                    if (int.Parse(verseReference[2]) == chapter)
                        if (int.Parse(verseReference[3]) == startVerse)
                        {
                            verseText += verseReference[4];
                            if (startVerse < endVerse) startVerse++;
                        }
        }
        return verseText;
    }
}
