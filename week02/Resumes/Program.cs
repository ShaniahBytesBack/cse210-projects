using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();

        Console.Write("Enter your name: ");
        myResume.Name = Console.ReadLine();

        Console.WriteLine("Enter job details (enter 'done' as title to finish):");
        while (true)
        {
            Job job = new Job();

            Console.Write("Job Title: ");
            string title = Console.ReadLine();
            if (title.ToLower() == "done") break;
            job.JobTitle = title;

            Console.Write("Company: ");
            job.Company = Console.ReadLine();

            Console.Write("Start Year: ");
            job.StartYear = int.Parse(Console.ReadLine());

            Console.Write("End Year: ");
            job.EndYear = int.Parse(Console.ReadLine());

            myResume.Jobs.Add(job);
        }

        Console.WriteLine("Enter skills (enter 'done' to finish):");
        while (true)
        {
            Console.Write("Skill: ");
            string skill = Console.ReadLine();
            if (skill.ToLower() == "done") break;
            myResume.Skills.Add(skill);
        }

        Console.WriteLine("\nYour Resume:");
        myResume.Display();
    }
}