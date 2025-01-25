// File: Program.cs

using System;

class Program
{
    static void Main(string[] args)
    {
        // Test default constructor
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString()); // Output: 1/1
        Console.WriteLine(fraction1.GetDecimalValue());  // Output: 1

        // Test constructor with one parameter
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString()); // Output: 5/1
        Console.WriteLine(fraction2.GetDecimalValue());  // Output: 5

        // Test constructor with two parameters
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString()); // Output: 3/4
        Console.WriteLine(fraction3.GetDecimalValue());  // Output: 0.75

        // Test setters and getters
        Fraction fraction4 = new Fraction();
        fraction4.SetNumerator(1);
        fraction4.SetDenominator(3);
        Console.WriteLine(fraction4.GetFractionString()); // Output: 1/3
        Console.WriteLine(fraction4.GetDecimalValue());  // Output: 0.3333333333333333

        // Test exception for denominator being zero
        try
        {
            Fraction fraction5 = new Fraction(1, 0);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
