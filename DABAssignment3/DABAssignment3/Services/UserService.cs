using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.SocialnetworkSettings;
using MongoDB.Driver;


namespace DABAssignment3.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(ISocialnetworkDBsettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);

        }

        public List<User> GetAll() =>
            _users.Find(User => true).ToList();

        public User Get(string Id) =>
            _users.Find<User>(User => User.UserId.ToString() == Id).FirstOrDefault();

        public User Create(User User)
        {
            _users.InsertOne(User);
            return User;
        }

        public void Update(string id, User UserIn) =>
            _users.ReplaceOne(User => User.UserId.ToString() == id, UserIn);

        public void Remove(User UserIn) =>
            _users.DeleteOne(User => User.UserId == UserIn.UserId);

        public void Remove(string id) =>
            _users.DeleteOne(User => User.UserId.ToString() == id);
    }
}
