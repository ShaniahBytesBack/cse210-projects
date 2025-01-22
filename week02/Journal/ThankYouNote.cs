using System;

public class ThankYouNote : Entry
{
    public string Recipient { get; set; }

    public ThankYouNote(string prompt, string response, string recipient)
        : base(prompt, response)
    {
        Recipient = recipient;
    }

    public override string ToFileFormat()
    {
        return $"THANK_YOU_NOTE|{Date}|{Prompt}|{Response}|{Recipient}";
    }

    public static new ThankYouNote FromFileFormat(string line)
    {
        var parts = line.Split('|');
        if (parts[0] == "THANK_YOU_NOTE")
        {
            return new ThankYouNote(parts[2], parts[3], parts[4]) { Date = parts[1] };
        }
        return null;
    }

    public override void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Recipient: {Recipient}\n");
    }
}
