using System;

class Program
{
    static void Main()
    {
        var scriptureLibrary = new ScriptureLibrary();

        scriptureLibrary.AddScripture(new Scripture(
            new Reference("John", "3", "16"),
            "For God so loved the world that he gave his only begotten Son"
        ));
        
        scriptureLibrary.AddScripture(new Scripture(
            new Reference("Proverbs", "3", "5", "6"),
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways acknowledge him, and he will make your paths straight."
        ));

        scriptureLibrary.AddScripture(new Scripture(
            new Reference("Philippians", "4", "13"),
            "I can do all things through Christ who strengthens me."
        ));

        var scripture = scriptureLibrary.GetRandomScripture();
        scripture.DisplayScripture();

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide more words, type 'unhide' to unhide all words, or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (input.ToLower() == "unhide")
            {
                scripture.UnhideAllWords();
                scripture.DisplayScripture();
            }
            else
            {
                scripture.HideRandomWords();
                scripture.DisplayScripture();
            }

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden! Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
}
