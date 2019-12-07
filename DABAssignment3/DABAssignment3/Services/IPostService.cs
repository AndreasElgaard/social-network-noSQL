using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using MongoDB.Bson;

namespace DABAssignment3.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post Get(ObjectId Id);

        Post Create(Post Post);

        void Update(ObjectId id, Post Post);

        void Remove(Post Post);
        void Remove(ObjectId id);
    }
}
