using TweetServer.Context;
using TweetServer.Models;

namespace TweetServer.Repositories
{
    public class TweetRepo : ITweetRepo
    {
        private ServerDbContext _context;

        public TweetRepo(ServerDbContext context)
        {
            _context = context;
        }

        public Tweet CreateTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            return tweet;
        }

        public List<Tweet> GetAll()
        {
            return (_context.Tweets.ToList());
        }

        public List<Tweet> GetTweetsByUser(string userId)
        {
            return _context.Tweets.Where(x => x.User_Id == userId).ToList(); 
        }

    }
}
