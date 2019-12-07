using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAssignment3.Models
{
    public class Circle
    {
        [BsonConstructor]
        public Circle()
        {

        }


        public Circle(string name)
        {
            UserId = new List<ObjectId>();
            PostId = new List<ObjectId>();
            Name = name;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CircleId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("PostId")]
        public List<ObjectId> PostId { get; set; }

        [BsonElement("UserId")]
        public List<ObjectId> UserId { get; set; }
    }
}
