using System;

public class Assignment
{
    private string _studentName;
    private string _topic;
    private DateTime _dueDate;
    private bool _isSubmitted;

    public Assignment(string studentName, string topic, DateTime dueDate)
    {
        _studentName = studentName;
        _topic = topic;
        _dueDate = dueDate;
        _isSubmitted = false; // Default is not submitted
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic} (Due: {_dueDate:MMMM dd, yyyy})";
    }

    public void MarkAsSubmitted()
    {
        _isSubmitted = true;
        Console.WriteLine($"Assignment for {_studentName} has been submitted.");
    }

    public bool IsLate()
    {
        return _isSubmitted && DateTime.Now > _dueDate;
    }

    public string GetSubmissionStatus()
    {
        return _isSubmitted ? (IsLate() ? "Submitted Late" : "Submitted On Time") : "Not Submitted";
    }

    public override string ToString()
    {
        return $"{GetSummary()} - Status: {GetSubmissionStatus()}";
    }

    protected string GetStudentName()
    {
        return _studentName;
    }
}
