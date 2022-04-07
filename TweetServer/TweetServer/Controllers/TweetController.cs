using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<TweetController> _logger;

        public TweetController(ILogger<TweetController> logger)
        {
            _logger = logger;
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
        public void Post([FromBody] string value)
        {
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
