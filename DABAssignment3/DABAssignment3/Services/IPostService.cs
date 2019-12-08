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
        Post Get(string Id);

        Post Create(Post Post);

        void Update(string id, Post Post);

        void Remove(Post Post);
        void Remove(string id);
    }
}
