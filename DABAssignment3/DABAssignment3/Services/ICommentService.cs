using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using MongoDB.Bson;

namespace DABAssignment3.Services
{
    public interface ICommentService 
    {
        List<Comment> GetAll();
        Comment Get(ObjectId Id);

        Comment Create(Comment Comment);

        void Update(ObjectId id, Comment Comment);

        void Remove(Comment Comment);
        void Remove(ObjectId id);
    }
}
