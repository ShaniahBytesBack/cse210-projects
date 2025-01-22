using System;
using System.Collections.Generic;

class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Program Menu");
            Console.WriteLine("1. Write a New General Entry");
            Console.WriteLine("2. Write a Thank You Note");
            Console.WriteLine("3. Display All Entries");
            Console.WriteLine("4. Display Specific Entry");
            Console.WriteLine("5. Save Journal to File");
            Console.WriteLine("6. Load Journal from File");
            Console.WriteLine("7. Edit an Entry");
            Console.WriteLine("8. Delete an Entry");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(myJournal);
                    break;

                case "2":
                    WriteThankYouNoteEntry(myJournal);
                    break;

                case "3":
                    myJournal.DisplayEntries();
                    break;

                case "4":
                    DisplaySpecificJournalEntry(myJournal);
                    break;

                case "5":
                    SaveJournal(myJournal);
                    break;

                case "6":
                    LoadJournal(myJournal);
                    break;

                case "7":
                    EditJournalEntry(myJournal);
                    break;

                case "8":
                    DeleteJournalEntry(myJournal);
                    break;

                case "9":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteNewEntry(Journal journal)
    {
        var random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        var entry = new Entry(prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Entry added successfully.\n");
    }

    static void WriteThankYouNoteEntry(Journal journal)
    {
        Console.Write("Who is the recipient of your thank-you note? ");
        string recipient = Console.ReadLine();
        Console.Write("Enter your thank-you message: ");
        string response = Console.ReadLine();

        journal.AddEntry(new ThankYouNote("Thank You Note", response, recipient));
        Console.WriteLine("Thank-you note added successfully.\n");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }

    static void EditJournalEntry(Journal journal)
    {
        Console.WriteLine("Entries:");
        journal.DisplayEntryList();
        Console.Write("Select the entry number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.Write("Enter the new response: ");
            string newResponse = Console.ReadLine();
            journal.EditEntry(index - 1, newResponse);
        }
        else
        {
            Console.WriteLine("Invalid input.\n");
        }
    }

    static void DeleteJournalEntry(Journal journal)
    {
        Console.WriteLine("Entries:");
        journal.DisplayEntryList();
        Console.Write("Select the entry number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            journal.DeleteEntry(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid input.\n");
        }
    }

    static void DisplaySpecificJournalEntry(Journal journal)
    {
        Console.WriteLine("Entries:");
        journal.DisplayEntryList();
        Console.Write("Select the entry number to view: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            journal.DisplaySpecificEntry(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid input.\n");
        }
    }
}
