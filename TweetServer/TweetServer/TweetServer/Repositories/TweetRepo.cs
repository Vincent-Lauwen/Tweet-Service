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

        public void CreateTweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public List<Tweet> GetAll()
        {
            return (_context.Tweets.ToList());
        }

        public List<Tweet> GetTweetsByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
