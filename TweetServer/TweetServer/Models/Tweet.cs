using System;

namespace TweetServer.Models
{
    public class Tweet
    {
        public string Id { get; private set; }
        public string Content { get; private set; }
        public int Likes { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string User_Id { get; private set; }
    }
}
