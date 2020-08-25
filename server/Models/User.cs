using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class User {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonRequired]
        public string Username { get; set; }

        [BsonRequired]
        public string Password { get; set; }

        [BsonRequired]
        public string email { get; set; }
    }
}