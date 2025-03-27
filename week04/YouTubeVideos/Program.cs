//Author : Diogo Rangel Dos Santos
//YouTube Videos Assingment
using System;
using System.Collections.Generic;

// Define the Comment class to hold information about a comment
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Define the Video class to hold information about a video and its comments
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display all comments
    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        // Create some sample comments
        Comment comment1 = new Comment("Diogo Rangel", "Sounds good bro. Good job.");
        Comment comment2 = new Comment("Adam Rangel", "Very Rom. Keep it up!");
        Comment comment3 = new Comment("Douglas Edutardo", "Interesting, but could use more examples.");
        Comment comment4 = new Comment("Eliete Francisco", "I disagree with some points, but nice effort.");

        // Create some sample videos
        Video video1 = new Video("Learning C#", "John Doe", 300);
        video1.Comments.Add(comment1);
        video1.Comments.Add(comment2);

        Video video2 = new Video("Mastering Java", "Jane Smith", 450);
        video2.Comments.Add(comment3);
        video2.Comments.Add(comment4);

        // Add videos to a list
        List<Video> videos = new List<Video> { video1, video2 };

        // Display details of each video and its comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}