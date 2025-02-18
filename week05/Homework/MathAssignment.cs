public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, DateTime dueDate, string textbookSection, string problems)
        : base(studentName, topic, dueDate)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems} ({GetDifficultyLevel()})";
    }

    private string GetDifficultyLevel()
    {
        int problemCount = _problems.Split(',').Length;
        if (problemCount < 5) return "Easy";
        if (problemCount < 10) return "Medium";
        return "Hard";
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {GetHomeworkList()}";
    }
}
