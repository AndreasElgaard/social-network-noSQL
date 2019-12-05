using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAssignment3.Models
{
    public class Post
    {
        [BsonConstructor]
        public Post()
        {

        }

        [BsonConstructor]
        public Post(string img, string text, bool ispublic, string circleid, string userid)
        {
            IMG = img;
            Text = text;
            Public = ispublic;
            CircleId = circleid;
            UserId = userid; 
            CommentId = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PostId { get; set; }

        [BsonElement("IMG")]
        public string IMG { get; set; }

        [BsonElement("Text")]
        public string Text { get; set; }

        [BsonElement("Public")]
        public bool Public { get; set; }

        [BsonElement("CircleId")]
        public string CircleId { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("CommentId")]
        public List<string> CommentId { get; set; }




    }
}
