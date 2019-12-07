using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.Dto;
using DABAssignment3.Models.SocialnetworkSettings;
using MongoDB.Bson;
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

        public User Get(ObjectId  Id) =>
            _users.Find<User>(User => User.UserId == Id).FirstOrDefault();

        public User FindByName(string Name) =>
            _users.Find(user => user.Name == Name).SingleOrDefault();
        

        public User Create(User User)
        {
            _users.InsertOne(User);
            return User;
        }
        
        public void Update(ObjectId id, User UserIn) =>
            _users.ReplaceOne(User => User.UserId == id, UserIn);

        public void Remove(User UserIn) =>
            _users.DeleteOne(User => User.UserId == UserIn.UserId);

        public void Remove(ObjectId id) =>
            _users.DeleteOne(User => User.UserId == id);

        public string SubsribeToUser(string UserName, string subscribeName)
        {
            var user = FindByName(UserName);
            var subscribe = FindByName(subscribeName);

            user.SubscriberId.Add(subscribe.UserId);

            Update(user.UserId, user);

            return "User Added To Subscriber list: " + subscribe.Name;
        }

        public string BlockUser(string UserName, string BlockUser)
        {
            var user = FindByName(UserName);
            var blocked = FindByName(BlockUser);

            user.BlockedUserId.Add(blocked.UserId);

            Update(user.UserId, user);

            return "User Blocked: " + blocked.Name;
        }

        public string UnSubsribeToUser(string UserName, string subscribeName)
        {
            var user = FindByName(UserName);
            var subscribe = FindByName(subscribeName);

            user.SubscriberId.Remove(subscribe.UserId);

            Update(user.UserId, user);

            return "UnSubscribered to User: " + subscribe.Name;
        }

        public string UnBlockUser(string UserName, string BlockUser)
        {
            var user = FindByName(UserName);
            var blocked = FindByName(BlockUser);

            user.BlockedUserId.Remove(blocked.UserId);

            Update(user.UserId, user);

            return "User UnBlocked: " + blocked.Name;
        }
    }
}
