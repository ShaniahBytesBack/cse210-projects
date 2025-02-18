using System;

class Program
{
    static void Main()
    {
        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", DateTime.Now.AddDays(3), "7.3", "3-10, 20-21");
        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", DateTime.Now.AddDays(5), "The Causes of World War II");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine("Submission Status: " + math.GetSubmissionStatus());
        
        math.MarkAsSubmitted();
        Console.WriteLine("Updated Submission Status: " + math.GetSubmissionStatus());

        Console.WriteLine("\n" + writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
        Console.WriteLine("Submission Status: " + writing.GetSubmissionStatus());

        writing.MarkAsSubmitted();
        Console.WriteLine("Updated Submission Status: " + writing.GetSubmissionStatus());
    }
}