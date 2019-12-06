using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.Dto;
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

        public User FindByName(string Name) =>
            _users.Find(user => user.Name == Name).SingleOrDefault();
        

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

        public WallResponse GetWall(string Userid, string guestId)
        {

            var result = Get(Userid);

            var wall = new WallResponse();

            foreach (var circle in result.CircleId)
            {
                var groups = 
            }






            return 
        }

        public string SubsribeToUser(string UserName, string subscribeName)
        {
            var user = FindByName(UserName);
            var subscribe = FindByName(subscribeName);

            user.SubscriberId.Add(subscribe.UserId.ToString());

            Update(user.UserId.ToString(), user);

            return "User Added To Subscriber list: " + subscribe.Name;
        }

        public string BlockUser(string UserName, string BlockUser)
        {
            var user = FindByName(UserName);
            var blocked = FindByName(BlockUser);

            user.BlockedUserId.Add(blocked.UserId.ToString());

            Update(user.UserId.ToString(), user);

            return "User Blocked: " + blocked.Name;
        }

        public string UnSubsribeToUser(string UserName, string subscribeName)
        {
            var user = FindByName(UserName);
            var subscribe = FindByName(subscribeName);

            user.SubscriberId.Remove(subscribe.UserId.ToString());

            Update(user.UserId.ToString(), user);

            return "UnSubscribered to User: " + subscribe.Name;
        }

        public string UnBlockUser(string UserName, string BlockUser)
        {
            var user = FindByName(UserName);
            var blocked = FindByName(BlockUser);

            user.BlockedUserId.Remove(blocked.UserId.ToString());

            Update(user.UserId.ToString(), user);

            return "User UnBlocked: " + blocked.Name;
        }
    }
}
