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
            UserId = new List<string>();
            PostId = new List<string>();
            Name = name;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId InternalId { get; set; }

        [BsonElement]
        public string CircleId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("PostId")]
        public List<string> PostId { get; set; }

        [BsonElement("UserId")]
        public List<string> UserId { get; set; }
    }
}
