using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using server.Models;
using Bcrypt = BCrypt.Net.BCrypt;

namespace server.Services
{
    public class UserService
    {
        private const bool V = false;
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

        public async Task<dynamic> Authenticate(AuthRequest authReq)
        {
            var account = (await _users.FindAsync(u => 
                u.email == authReq.email || u.Username == authReq.username
            )).FirstOrDefault();

            if (account == null || !Bcrypt.Verify(authReq.password, account.Password))
            {
                return !!V;
            }
            else
            {
                return generateJwtToken(account);
            }
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new RSACryptoServiceProvider(2048);
            var tokenOptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(key), SecurityAlgorithms.RsaSha256)
            };

            var token = tokenHandler.CreateToken(tokenOptions);
            return tokenHandler.WriteToken(token);
        }
    }
}