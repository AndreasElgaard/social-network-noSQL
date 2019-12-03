using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAssignment3.Models
{
    public class Wall
    {
        public Wall(ObjectId WallId, User user)
        {
            this.WallId = WallId;
        }
        [BsonId]
        public ObjectId WallId { get; set; }
        [BsonElement("GuestId")]
        public ObjectId GuestId { get; set; }
        [BsonElement("Many")]
        private ObjectId Users { get; set; }
    }
}
