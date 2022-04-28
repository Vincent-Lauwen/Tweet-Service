using Microsoft.EntityFrameworkCore;
using TweetServer.Models;

namespace TweetServer.Context
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options)
        {

        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}
