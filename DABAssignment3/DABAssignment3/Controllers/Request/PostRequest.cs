using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers
{
    public class PostRequest
    {
        public string PostId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string? CircleId{ get; set; }

        public string UserId { get; set; }

        public string IMG { get; set; }

        public bool Public { get; set; }
    }
}
