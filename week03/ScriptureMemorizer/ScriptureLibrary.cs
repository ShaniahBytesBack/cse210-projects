using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    public List<Scripture> Scriptures { get; set; }

    public ScriptureLibrary()
    {
        Scriptures = new List<Scripture>();
    }

    public void AddScripture(Scripture scripture)
    {
        Scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        var random = new Random();
        return Scriptures[random.Next(Scriptures.Count)];
    }
}
