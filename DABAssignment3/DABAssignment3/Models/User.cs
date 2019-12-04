using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAssignment3.Models
{
    public class User
    {
        [BsonConstructor]
        public User(string name, int age, string gender)
        {
            Name = Name;
            Age = age;
            Gender = gender;
            PostId = new List<string>();
            SubscriberId = new List<string>();
            BlockedUserId = new List<string>();
            CircleId = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("PostId")]
        public List<string> PostId { get; set; }

        [BsonElement("CircleId")]
        public List<string> CircleId { get; set; }

        [BsonElement("SubscriberId")]
        public List<string> SubscriberId { get; set; }

        [BsonElement("BlockedUser")]
        public List<string> BlockedUserId { get; set; }

        //[BsonElement("Wall")]
        //public List<string> Wall { get; set; }

        //[BsonElement("Feed")]
        //public List<string> Feed { get; set; }

    }
}
