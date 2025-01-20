using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Guess My Number game!");

        PlayGame();
    }

    static void PlayGame()
    {
        Random random = new Random();

        int magicNumber = random.Next(1, 101);

        int guess = 0;

        int numberOfGuesses = 0;

        int maxGuesses = 10;

        while (guess != magicNumber && numberOfGuesses < maxGuesses)
        {
            Console.WriteLine($"\nAttempt {numberOfGuesses + 1} of {maxGuesses}.");
            Console.Write("What is your guess? ");

            bool validInput = int.TryParse(Console.ReadLine(), out guess);

            if (!validInput)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                continue; // Skip the rest of the loop and prompt the user again
            }

            numberOfGuesses++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                break;
            }

            if (numberOfGuesses == maxGuesses)
            {
                Console.WriteLine($"Sorry, you've reached the maximum number of guesses. The magic number was {magicNumber}.");
                break;
            }
        }

        PlayAgain();
    }

    static void PlayAgain()
    {
        Console.Write("\nDo you want to play again? (yes/no): ");
        string response = Console.ReadLine().ToLower();

        if (response == "yes")
        {
            PlayGame();
        }
        else
        {
            Console.WriteLine("Thanks for playing! Goodbye.");
        }
    }
}
