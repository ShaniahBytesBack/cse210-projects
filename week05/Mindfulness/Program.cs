using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text.Json;
using System.Threading;

abstract class MindfulnessActivity
{
    public string Name { get; }
    public string Description { get; }
    public int Duration { get; set; }

    protected MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {Name}: {Description}");
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public virtual void End()
    {
        Console.WriteLine($"Well done! You have completed {Name} for {Duration} seconds.");
        Thread.Sleep(2000);
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "Relax by breathing in and out slowly.") { }

    public override void Start()
    {
        base.Start();
        for (int i = 0; i < Duration / 6; i++)
        {
            Console.Write("Breathe in... "); Thread.Sleep(3000);
            Console.Write("Breathe out... "); Thread.Sleep(3000);
        }
        base.End();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts =
    {
        "Think of a time you helped someone in need.",
        "Think of a time you achieved something difficult.",
        "Think of a time you felt truly proud."
    };
    
    public ReflectionActivity() : base("Reflection Activity", "Think deeply about moments of strength.") { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine(Prompts[new Random().Next(Prompts.Length)]);
        Thread.Sleep(3000);
        base.End();
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing Activity", "List positive things in your life.") { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Enter as many positive things as you can:");
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> responses = new List<string>();
        while (DateTime.Now < endTime)
        {
            responses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {responses.Count} items!");
        base.End();
    }
}

class UserProfile
{
    public string Username { get; }
    public List<(string Activity, int Duration, DateTime Timestamp)> History { get; } = new();

    public UserProfile(string username)
    {
        Username = username;
        LoadData();
    }

    public void LogActivity(string activity, int duration)
    {
        History.Add((activity, duration, DateTime.Now));
        SaveData();
    }

    private void SaveData()
    {
        File.WriteAllText($"{Username}.json", JsonSerializer.Serialize(History));
    }

    private void LoadData()
    {
        if (File.Exists($"{Username}.json"))
            History.AddRange(JsonSerializer.Deserialize<List<(string, int, DateTime)>>(
                File.ReadAllText($"{Username}.json")));
    }

    public void ShowProgress()
    {
        Console.WriteLine($"{Username}'s Progress:");
        foreach (var entry in History)
            Console.WriteLine($"{entry.Timestamp}: {entry.Activity} ({entry.Duration}s)");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        var user = new UserProfile(Console.ReadLine());
        var activities = new Dictionary<string, MindfulnessActivity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Progress");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (activities.ContainsKey(choice))
            {
                activities[choice].Start();
                user.LogActivity(activities[choice].Name, activities[choice].Duration);
            }
            else if (choice == "4")
                user.ShowProgress();
            else if (choice == "5")
                break;
        }
    }
}
