public class Reference
{
    public string Book { get; set; }
    public string Chapter { get; set; }
    public string Verse { get; set; }
    public string VerseEnd { get; set; }

    public Reference(string book, string chapter, string verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        VerseEnd = null;
    }

    public Reference(string book, string chapter, string verse, string verseEnd)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        VerseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        if (VerseEnd != null)
        {
            return $"{Book} {Chapter}:{Verse}-{VerseEnd}";
        }
        return $"{Book} {Chapter}:{Verse}";
    }
}
