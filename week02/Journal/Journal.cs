using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.\n");
            return;
        }

        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine("Journal saved successfully.\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("ENTRY"))
                {
                    _entries.Add(Entry.FromFileFormat(line));
                }
                else if (line.StartsWith("THANK_YOU_NOTE"))
                {
                    _entries.Add(ThankYouNote.FromFileFormat(line));
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.\n");
    }

    public void EditEntry(int index, string newResponse)
    {
        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("Invalid entry index.\n");
            return;
        }

        _entries[index].Response = newResponse;
        Console.WriteLine("Entry updated successfully.\n");
    }

    public void DeleteEntry(int index)
    {
        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("Invalid entry index.\n");
            return;
        }

        _entries.RemoveAt(index);
        Console.WriteLine("Entry deleted successfully.\n");
    }

    public void DisplayEntryList()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_entries[i].Prompt} ({_entries[i].Date})");
        }
    }

    public void DisplaySpecificEntry(int index)
    {
        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("Invalid entry index.\n");
            return;
        }

        _entries[index].Display();
    }
}
