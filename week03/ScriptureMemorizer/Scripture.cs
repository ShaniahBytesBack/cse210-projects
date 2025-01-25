using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>();

        // Split the text into words and create Word objects
        foreach (var word in text.Split(' '))
        {
            Words.Add(new Word(word));
        }
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(Reference.GetDisplayText());
        foreach (var word in Words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        var random = new Random();
        int wordIndex = random.Next(Words.Count);
        if (!Words[wordIndex].IsHidden())
        {
            Words[wordIndex].HideWord();
        }
        else
        {
            HideRandomWords();  // Recursively call if the word is already hidden
        }
    }

    public void UnhideAllWords()
    {
        foreach (var word in Words)
        {
            word.UnhideWord();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden());
    }
}
