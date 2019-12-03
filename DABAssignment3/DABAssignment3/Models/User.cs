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
        public User(ObjectId UserID, string name, int age, string gender, Group group)
        {
            this.UserID = UserID;
            Name = Name;
            Age = age;
            Gender = gender;
            Groups = group.GroupId;
        }

        [BsonId]
        public ObjectId UserID { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Age")]
        public int Age { get; set; }
        [BsonElement("Gender")]
        public string Gender { get; set; }
        [BsonElement("Many")]
        public List<ObjectId> Groups { get; set; }
    }
}
