using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        
        while (true)
        {
            Console.WriteLine("\n1. Create Simple Goal");
            Console.WriteLine("2. Create Eternal Goal");
            Console.WriteLine("3. Create Checklist Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. View Goals");
            Console.WriteLine("6. View Score");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");
            
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter description: ");
                string desc = Console.ReadLine();
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine());

                manager.CreateSimpleGoal(name, desc, points);
            }
            else if (choice == 2)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter description: ");
                string desc = Console.ReadLine();
                Console.Write("Enter points per event: ");
                int points = int.Parse(Console.ReadLine());

                manager.CreateEternalGoal(name, desc, points);
            }
            else if (choice == 3)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter description: ");
                string desc = Console.ReadLine();
                Console.Write("Enter points per event: ");
                int points = int.Parse(Console.ReadLine());
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                manager.CreateChecklistGoal(name, desc, points, target, bonus);
            }
            else if (choice == 4) manager.DisplayGoals();
            else if (choice == 5) manager.DisplayGoals();
            else if (choice == 6) manager.DisplayScore();
            else if (choice == 7) manager.SaveToFile();
            else if (choice == 8) manager.LoadFromFile();
            else break;
        }
    }
}

