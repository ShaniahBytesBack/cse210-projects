
using System;
using System.Collections.Generic;

public class Resume
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be empty.");
    }

    public List<Job> Jobs { get; set; } = new List<Job>();
    public List<string> Skills { get; set; } = new List<string>();

    public void Display()
    {
        Console.WriteLine($"Name: {Name}");

        Console.WriteLine();

        Console.WriteLine("Jobs:");

        Console.WriteLine();

        foreach (var job in Jobs)
        {
            job.Display();
        }
        
        Console.WriteLine(); 

        Console.WriteLine("Skills:");

        Console.WriteLine();
        foreach (var skill in Skills)
        {
            Console.WriteLine($"- {skill}");
        }
    }
}
