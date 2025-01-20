using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompts user for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompts the user for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Prints their full name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
