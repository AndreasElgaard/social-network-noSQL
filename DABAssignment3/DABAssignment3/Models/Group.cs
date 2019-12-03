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
    public class Group
    {
        public Group(ObjectId GroupID, string name)
        {
            this.GroupId = GroupID;
            Name = name; 
            Users = new List<User>();
        }
        [BsonId]
        public ObjectId GroupId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Many")]
        private List<User> Users {get; set;}
    }
}
