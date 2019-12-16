using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers.Request
{
    public class CircleRequest
    {
        public string CircleId { get; set; }

        public string Name { get; set; }

        public List<string> UserId { get; set; }

        public List<string> PostId { get; set; }
    }
}
