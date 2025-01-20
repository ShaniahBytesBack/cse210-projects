using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Enter numbers to calculate (0 to stop):");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNumber}");
    }

    static void HandleMultipleNumbers()
    {
        List<int> numbers = new List<int>();
        int number;

        while (true)
        {
            number = PromptUserNumber();
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int largest = numbers.Max();

            Console.WriteLine();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }

    static int PromptFavoriteNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    static void Main()
    {
        DisplayWelcome();
        string userName = PromptUserName();

        Console.WriteLine();

        HandleMultipleNumbers();

        Console.WriteLine();

        Console.WriteLine("Now let's calculate your favorite number!");
        int userFavoriteNumber = PromptFavoriteNumber();

        Console.WriteLine();

        int squaredNumber = SquareNumber(userFavoriteNumber);

        DisplayResult(userName, squaredNumber);

        Console.WriteLine();
    }
}
