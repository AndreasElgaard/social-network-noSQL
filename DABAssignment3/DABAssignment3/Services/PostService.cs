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

        public PostService()
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<Post>(settings.BooksCollectionName);

        }

        public List<Post> GetAll() =>
            _posts.Find(post => true).ToList();

        public Post Get(string Id) =>
            _posts.Find<Post>(post => post.PostId == Id).FirstOrDefault();

        public Post Create(Post Post)
        {
            _posts.InsertOne(Post);
            return Post;
        }

        public void Update(string id, Post Post) =>
            _posts.ReplaceOne(post => post.PostId.ToString == id, Post);

        public void Remove(Post Post) =>
            _posts.DeleteOne(post => post.PostId == Post.PostId);

        public void Remove(string id) =>
            _posts.DeleteOne(post => post.PostId == id);
    }
}
