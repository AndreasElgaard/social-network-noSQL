using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DABAssignment3.Controllers.Request
{
    public class CircleUserRequest
    {
        public ObjectId CircleId { get; set; }

        public ObjectId UserId { get; set; }
    }
}
