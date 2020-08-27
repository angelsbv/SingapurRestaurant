using MongoDB.Driver;
using server.Models;

namespace server.Services{
    public class UserService{ 

        private readonly IMongoCollection<User> _users;

        public UserService(ISRDBSettings settings)
        {
            var client = new MongoClient(settings.DBstr);
            var db = client.GetDatabase(settings.DBname);
            
            _users = db.GetCollection<User>(settings.UsersCollection);
        }
    }
}