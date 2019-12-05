using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using MongoDB.Driver;

namespace DABAssignment3.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService()

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(string Id)
        {
            throw new NotImplementedException();
        }

        public User Create(User User)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, User User)
        {
            throw new NotImplementedException();
        }

        public void Remove(User User)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
