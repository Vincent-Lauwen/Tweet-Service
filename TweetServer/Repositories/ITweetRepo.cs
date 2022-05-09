using TweetServer.Models;

namespace TweetServer.Repositories
{
    public interface ITweetRepo
    {
        List<Tweet> GetAll();
        List<Tweet> GetTweetsByUser(string userId);
        Tweet CreateTweet(Tweet tweet);
    }
}
