using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAssignment3.Models
{
    public class Comment
    {
        [BsonConstructor]
        public Comment()
        {

        }

        public Comment(string text, string postid, string userid)
        {
            PostId = postid;
            UserId = userid; 
            Text = text;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CommentId { get; set; }

        [BsonElement("Text")]
        public string Text { get; set; }

        [BsonElement("PostId")]
        public string PostId { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }
    }
}
