using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers.Request
{
    public class CircleRequest
    {
        public ObjectId CircleId { get; set; }

        public string Name { get; set; }

        public List<ObjectId> UserId { get; set; }

        public List<ObjectId> PostId { get; set; }
    }
}
