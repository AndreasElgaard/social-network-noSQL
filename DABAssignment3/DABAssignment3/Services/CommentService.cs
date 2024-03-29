﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.SocialnetworkSettings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DABAssignment3.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMongoCollection<Comment> _comment;

        public CommentService(ISocialnetworkDBsettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _comment = database.GetCollection<Comment>(settings.CommentCollectionName);
        }

        public List<Comment> GetAll()
        {
            return _comment.Find(book => true).ToList();
        }

        public Comment Get(string Id)
        {
            return _comment.Find<Comment>(comment => comment.CommentId == Id).FirstOrDefault();
        }

        public Comment Create(Comment Comment)
        {
            _comment.InsertOne(Comment);
            return Comment;
        }

        public void Update(string id, Comment Comment)
        {
            _comment.ReplaceOne(comment => comment.CommentId == id, Comment);
        }

        public void Remove(Comment Comment)
        {
            _comment.DeleteOne(comment=> comment.CommentId == Comment.CommentId);
        }

        public void Remove(string id)
        {
            _comment.DeleteOne(comment => comment.CommentId == id);
        }
    }
}
