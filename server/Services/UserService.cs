using System.Threading.Tasks;
using MongoDB.Driver;
using server.Models;
using Bcrypt = BCrypt.Net.BCrypt;

namespace server.Services
{
    public class UserService
    {

        private readonly IMongoCollection<User> _users;

        public UserService(ISRDBSettings settings)
        {
            var client = new MongoClient(settings.DBstr);
            var db = client.GetDatabase(settings.DBname);

            _users = db.GetCollection<User>(settings.UsersCollection);
        }

        public async Task<User> Register(User user)
        {
            user.Password = Bcrypt.HashPassword(user.Password);
            await _users.InsertOneAsync(user);
            return user;
        }

        #nullable enable
        public async Task<bool> Authenticate(AuthRequest authReq)
        {
            var account = (await _users.FindAsync(u => 
                u.email == authReq.email || u.Username == authReq.username
            )).FirstOrDefault();

            if (account == null || !Bcrypt.Verify(authReq.password, account.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #nullable disable
    }
}