using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DABAssignment3.Controllers.Request
{
    public class CircleUserRequest
    {
        public string CircleId { get; set; }

        public string UserId { get; set; }
    }
}
