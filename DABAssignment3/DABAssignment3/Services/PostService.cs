using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using MongoDB.Driver;

namespace DABAssignment3.Services
{
    public class PostService : IPostService
    {
        private readonly IMongoCollection<Post> _posts;
        PostService()
        {
            var client = new MongoClient("\"mongodb://localhost:27017\"");
        }
        public List<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post Get(string Id)
        {
            throw new NotImplementedException();
        }

        public Post Create(Post Post)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Post Post)
        {
            throw new NotImplementedException();
        }

        public void Remove(Post Post)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
