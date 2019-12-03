using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace DABAssignment3.Models
{
    public class Feed
    {
        public Feed(ObjectId FeedId, User user)
        {
            this.FeedId = FeedId;
            Users = user;
        }
        [BsonId]
        public ObjectId FeedId { get; set; }
        [BsonElement("Many")]
        private User Users { get; set; }
    }
}
