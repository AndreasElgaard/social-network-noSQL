using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.SocialnetworkSettings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DABAssignment3.Services
{
    public class PostService : IPostService
    {
        private readonly IMongoCollection<Post> _posts;

        public PostService(ISocialnetworkDBsettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            BsonClassMap.RegisterClassMap<Post>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(p => new Post(p.IMG, p.Text, p.Public, p.CircleId, p.UserId));
            });

            _posts = database.GetCollection<Post>(settings.PostCollectionName);
        }

        public List<Post> GetAll() =>
            _posts.Find(post => true).ToList();

        public Post Get(ObjectId Id) =>
            _posts.Find<Post>(post => post.PostId == Id).FirstOrDefault();

        public Post Create(Post Post)
        {
            _posts.InsertOne(Post);
            return Post;
        }

        public void Update(ObjectId id, Post Post) =>
            _posts.ReplaceOne(post => post.PostId == id, Post);

        public void Remove(Post Post) =>
            _posts.DeleteOne(post => post.PostId == Post.PostId);

        public void Remove(ObjectId id) =>
            _posts.DeleteOne(post => post.PostId == id);
    }
}
