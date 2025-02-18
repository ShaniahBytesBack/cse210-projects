using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Base class for all activities
abstract class Activity
{
    protected DateTime Date;
    protected int Minutes;

    public Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract double GetCaloriesBurned();
    
    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")}: {GetType().Name} ({Minutes} min) - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min/km, Calories Burned: {GetCaloriesBurned():0.0}";
    }
}

// Running activity
class Running : Activity
{
    private double Distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        Distance = distance;
    }

    public override double GetDistance() => Distance;
    public override double GetSpeed() => (Distance / Minutes) * 60;
    public override double GetPace() => Minutes / Distance;
    public override double GetCaloriesBurned() => Minutes * 10;
}

// Cycling activity
class Cycling : Activity
{
    private double Speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        Speed = speed;
    }

    public override double GetDistance() => (Speed * Minutes) / 60;
    public override double GetSpeed() => Speed;
    public override double GetPace() => 60 / Speed;
    public override double GetCaloriesBurned() => Minutes * 8;
}

// Swimming activity
class Swimming : Activity
{
    private int Laps;
    private const double LapLength = 50.0 / 1000; // 50 meters in km

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance() => Laps * LapLength;
    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
    public override double GetCaloriesBurned() => Minutes * 11;
}

// Yoga activity
class Yoga : Activity
{
    private string Style;

    public Yoga(DateTime date, int minutes, string style) : base(date, minutes)
    {
        Style = style;
    }

    public override double GetDistance() => 0;
    public override double GetSpeed() => 0;
    public override double GetPace() => 0;
    public override double GetCaloriesBurned() => Minutes * 5;

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")}: {GetType().Name} ({Minutes} min) - Style: {Style}, Calories Burned: {GetCaloriesBurned():0.0}";
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 3), 25, 40),
            new Yoga(new DateTime(2022, 11, 3), 60, "Hatha")
        };

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nExercise Tracking Summary\n--------------------------");
        Console.ResetColor();

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        double totalCalories = activities.Sum(a => a.GetCaloriesBurned());
        Console.WriteLine($"\nTotal Calories Burned: {totalCalories:0.0}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nKeep up the great work! Stay active and healthy!");
        Console.ResetColor();
    }
}
