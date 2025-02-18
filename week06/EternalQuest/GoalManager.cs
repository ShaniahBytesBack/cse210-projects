using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateSimpleGoal(string name, string description, int points)
    {
        _goals.Add(new SimpleGoal(name, description, points));
    }

    public void CreateEternalGoal(string name, string description, int points)
    {
        _goals.Add(new EternalGoal(name, description, points));
    }

    public void CreateChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
    {
        _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _score += _goals[goalIndex].RecordEvent();
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} - {_goals[i].GetDetailsString()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {_score}");
    }

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetDetailsString());
            }
        }
    }

    public void LoadFromFile()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);
        }
    }
}
