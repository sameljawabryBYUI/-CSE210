using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Understanding C# Classes", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation of abstraction!"));
        video1.AddComment(new Comment("Bob", "This helped me with my homework."));
        video1.AddComment(new Comment("Charlie", "Could you do a video on interfaces next?"));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Programming Languages in 2026", "TechGuru", 900);
        video2.AddComment(new Comment("Dave", "Python is definitely #1 for me."));
        video2.AddComment(new Comment("Eve", "Where is Rust on this list?"));
        video2.AddComment(new Comment("Frank", "Nice production quality."));
        video2.AddComment(new Comment("Grace", "C# should be higher!"));
        videos.Add(video2);

        Video video3 = new Video("Day in the Life of a Software Engineer", "DevVlogs", 1200);
        video3.AddComment(new Comment("Heidi", "Love seeing the actual day-to-day work."));
        video3.AddComment(new Comment("Ivan", "Do you work remotely full time?"));
        video3.AddComment(new Comment("Judy", "The coffee montage was the best part."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}