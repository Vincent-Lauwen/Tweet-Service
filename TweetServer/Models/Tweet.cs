using System;
using System.ComponentModel.DataAnnotations;

namespace TweetServer.Models
{
    public class Tweet
    {
        public Tweet(string id, string content, int likes, DateTime publishDate, string user_Id)
        {
            Id = id;
            Content = content;
            Likes = likes;
            PublishDate = publishDate;
            User_Id = user_Id;
        }
        public Tweet()
        {

        }

        public string Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public DateTime PublishDate { get; set; }
        public string User_Id { get; set; }

        
    }
}
