using Microsoft.AspNetCore.Mvc;
using RabbitMQ;
using TweetServer.Models;
using TweetServer.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private ITweetRepo _repository;
        private readonly IMessageProducer _messagePublisher;

        public TweetController(ITweetRepo repo, IMessageProducer messagePublisher)
        {
            _repository = repo;
            _messagePublisher = messagePublisher;
        }

        // GET: api/<TweetController>
        [HttpGet("/rabbit")]
        public void RabbitMQSenderTest()
        {
            try
            {
                _messagePublisher.SendMessage("dit is een test");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // GET: api/<TweetController>
        [HttpGet]
        public ActionResult<IEnumerable<Tweet>> GetTweets()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TweetController>/5
        [HttpGet("/user/{id}")]
        public ActionResult<IEnumerable<Tweet>> GetTweetsByUser (string id)
        {
            try
            {
                return _repository.GetTweetsByUser(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TweetController>
        [HttpPost]
        public ActionResult<Tweet> PostTweet([FromBody] Tweet tweet)
        {
            try
            {
                if (tweet == null || tweet.Content == null)
                {
                    return BadRequest("Tweets' message is null or message invalid");
                }

                var createdTweet = _repository.CreateTweet(tweet);

                return Ok(tweet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TweetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TweetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
