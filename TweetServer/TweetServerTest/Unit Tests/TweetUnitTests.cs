using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TweetServer.Context;
using TweetServer.Models;
using TweetServer.Repositories;

namespace TweetServerTest
{
    [TestClass]
    public class TweetUnitTests
    {
        private ServerDbContext _context;
        private ITweetRepo _tweetRepo;

        [TestInitialize]
        public void Setup()
        {
            var dbContextOptions =
                new DbContextOptionsBuilder<ServerDbContext>().UseInMemoryDatabase(databaseName: "MockDB");
            _context = new ServerDbContext(dbContextOptions.Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.AddRange(
                new Tweet("1", "Eerste content", 2, DateTime.Now, "a"),
                new Tweet("2", "Tweede content", 4, DateTime.Now, "b"),
                new Tweet("3", "Derde content", 6, DateTime.Now, "c")
            );

            _context.SaveChanges();

            _tweetRepo = new TweetRepo(_context);
        }

        [TestMethod]
        public void Get_All_Claims()
        {
            List<Tweet> tweets = _tweetRepo.GetAll();

            Assert.AreEqual(3, tweets.Count);
            Assert.AreEqual("Eerst content", tweets[0].Content);
        }
    }
}