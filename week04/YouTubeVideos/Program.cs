// File path: week04/YouTubeVideos.cs

using System;
using System.Collections.Generic;
using System.Linq;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public string GetSentiment()
    {
        // Simple sentiment analysis using keyword matching
        string[] positiveWords = { "love", "great", "awesome", "amazing", "useful", "helpful" };
        string[] negativeWords = { "hate", "bad", "confusing", "frustrating", "boring" };

        string lowerText = Text.ToLower();
        if (positiveWords.Any(word => lowerText.Contains(word))) return "Positive 😊";
        if (negativeWords.Any(word => lowerText.Contains(word))) return "Negative 😞";
        return "Neutral 😐";
    }

    public override string ToString()
    {
        return $"{Name}: {Text} ({GetSentiment()})";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // In seconds
    public string Category { get; set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length, string category)
    {
        Title = title;
        Author = author;
        Length = length;
        Category = category;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public List<Comment> FilterComments(string keyword)
    {
        return Comments.Where(comment => comment.Text.ToLower().Contains(keyword.ToLower())).ToList();
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"\n📹 Title: {Title}");
        Console.WriteLine($"👤 Author: {Author}");
        Console.WriteLine($"⏳ Length: {Length} seconds");
        Console.WriteLine($"📂 Category: {Category}");
        Console.WriteLine($"💬 Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("📢 Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        List<string> categories = new List<string> { "Cooking", "Programming", "Travel", "Education", "Lifestyle" };
        Random rand = new Random();

        // Create Video objects with random categories
        Video video1 = new Video("How to Cook Pasta", "Chef John", 300, categories[rand.Next(categories.Count)]);
        Video video2 = new Video("Python Programming Basics", "Code Academy", 600, categories[rand.Next(categories.Count)]);
        Video video3 = new Video("Traveling to Japan", "Explorer Jane", 900, categories[rand.Next(categories.Count)]);

        // Add comments
        video1.AddComment(new Comment("Alice", "Great recipe! I love this."));
        video1.AddComment(new Comment("Bob", "Tried it and hated it!"));
        video1.AddComment(new Comment("Charlie", "Can I use gluten-free pasta?"));

        video2.AddComment(new Comment("Dave", "Awesome tutorial! Very useful."));
        video2.AddComment(new Comment("Eve", "Confusing and frustrating at times."));
        video2.AddComment(new Comment("Frank", "Can't wait for the next one."));

        video3.AddComment(new Comment("Grace", "Japan looks amazing!"));
        video3.AddComment(new Comment("Heidi", "Thanks for the travel tips."));
        video3.AddComment(new Comment("Ivan", "This video made my day. Do you recommend Kyoto?"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information
        Console.WriteLine("\n🎬 === YouTube Video Tracker ===");
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }

        // Keyword filtering
        Console.Write("\n🔍 Enter a keyword to filter comments (e.g., 'love', '?'): ");
        string keyword = Console.ReadLine();

        Console.WriteLine($"\n🔎 === Filtered Comments by Keyword: '{keyword}' ===");
        foreach (var video in videos)
        {
            var filteredComments = video.FilterComments(keyword);
            if (filteredComments.Count > 0)
            {
                Console.WriteLine($"\n📹 {video.Title}");
                foreach (var comment in filteredComments)
                {
                    Console.WriteLine($"  - {comment}");
                }
            }
        }
    }
}
