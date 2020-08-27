using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models { 
    public class User { 

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId, AllowTruncation = true)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        public string email { get; set; }
    }
}