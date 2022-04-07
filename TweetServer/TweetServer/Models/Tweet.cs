using System;

namespace TweetServer.Models
{
    public class Tweet
    {
        public string Id { get; private set; }
        public string Content { get; private set; }
        public int Likes { get; private set; }
        public DateTime PublishDate { get; private set; }

        public Tweet()
        {

        }

        public Tweet(string id, string content, int likes, DateTime publishDate)
        {
            Id = id;
            Content = content;
            Likes = likes;
            PublishDate = publishDate;
        }
    }
}
