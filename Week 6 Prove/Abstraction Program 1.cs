using System;
using System.Collections.Generic;

// Abstract class representing a media item
abstract class MediaItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
}

// Class representing a YouTube video
class Video : MediaItem
{
    private List<Comment> comments;

    public Video()
    {
        comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public void DisplayInformation()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + LengthInSeconds + " seconds");
        Console.WriteLine("Number of Comments: " + GetNumberOfComments());

        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine("Comment by " + comment.Name + ": " + comment.Text);
        }

        Console.WriteLine();
    }
}

// Class representing a comment on a YouTube video
class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos
        Video video1 = new Video
        {
            Title = "Video 1",
            Author = "Author 1",
            LengthInSeconds = 120
        };
        video1.AddComment(new Comment { Name = "User1", Text = "Great video!" });
        video1.AddComment(new Comment { Name = "User2", Text = "I learned a lot." });
        videos.Add(video1);

        Video video2 = new Video
        {
            Title = "Video 2",
            Author = "Author 2",
            LengthInSeconds = 180
        };
        video2.AddComment(new Comment { Name = "User3", Text = "Interesting content." });
        video2.AddComment(new Comment { Name = "User4", Text = "Could be better." });
        video2.AddComment(new Comment { Name = "User5", Text = "Nice work!" });
        videos.Add(video2);

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayInformation();
        }

        Console.ReadLine();
    }
}
