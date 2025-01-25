public class Word
{
    public string Text { get; set; }
    private bool Hidden { get; set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void HideWord()
    {
        Hidden = true;
    }

    public void UnhideWord()
    {
        Hidden = false;
    }

    public bool IsHidden()
    {
        return Hidden;
    }

    public string GetDisplayText()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }
}
