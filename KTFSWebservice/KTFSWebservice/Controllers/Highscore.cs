using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Text.Json;

namespace KTFSWebservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class highscore : ControllerBase
    {
        static MongoClient dbClient = new MongoClient("mongodb+srv://ktfsgameserver:ktfsfpsgame@ktfs.o5iwxxd.mongodb.net/test");
        static IMongoDatabase database = dbClient.GetDatabase("Game");

        [HttpGet(Name = "GetHighscore")]
        public IEnumerable<PlayerScore> Get()
        {
            var collection = database.GetCollection<PlayerScore>("scores");
            List<PlayerScore> result = collection.Find(Builders<PlayerScore>.Filter.Empty).ToList();
            return result;
        }



        [HttpPost(Name = "PostHighscore")]
        public void Post(string name, int score)
        {
            // convert JSON string to PlayerScore
            //var test = JsonSerializer.Deserialize<PlayerScore>(postedData);

            // Pull data from the sendt form

            PlayerScore ps = new PlayerScore(score, name);

            var collection = database.GetCollection<PlayerScore>("scores");
            collection.InsertOne(ps);

            //collection.InsertOne(/* PlayerScore */);
        }


    }
}


