using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KTFSWebservice
{
    public class PlayerScore
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public PlayerScore(int score, string name)
        {
            _id = ObjectId.GenerateNewId();
            Score = score;
            Name = name;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
    }
}
