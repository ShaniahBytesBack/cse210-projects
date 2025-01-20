using System;

public class Job
{
    private string _jobTitle;
    private string _company;
    private int _startYear;
    private int _endYear;

    public string JobTitle
    {
        get => _jobTitle;
        set => _jobTitle = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Job title cannot be empty.");
    }

    public string Company
    {
        get => _company;
        set => _company = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Company cannot be empty.");
    }

    public int StartYear
    {
        get => _startYear;
        set => _startYear = value >= 1900 && value <= DateTime.Now.Year ? value : throw new ArgumentException("Invalid start year.");
    }

    public int EndYear
    {
        get => _endYear;
        set => _endYear = value >= _startYear && value <= DateTime.Now.Year + 10 ? value : throw new ArgumentException("Invalid end year.");
    }

    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}
