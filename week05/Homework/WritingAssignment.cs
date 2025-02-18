public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, DateTime dueDate, string title)
        : base(studentName, topic, dueDate)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {_title}";
    }
}
