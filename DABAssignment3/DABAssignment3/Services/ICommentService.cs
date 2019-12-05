using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;

namespace DABAssignment3.Services
{
    public interface ICommentService 
    {
        List<Comment> GetAll();
        Comment Get(string Id);

        Comment Create(Comment Comment);

        void Update(string id, Comment Comment);

        void Remove(Comment Comment);
        void Remove(string id);
    }
}
