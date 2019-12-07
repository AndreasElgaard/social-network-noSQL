using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers
{
    public class PostRequest
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public ObjectId? CircleId{ get; set; }

        public ObjectId UserId { get; set; }

        public string IMG { get; set; }

        public bool Public { get; set; }
    }
}
