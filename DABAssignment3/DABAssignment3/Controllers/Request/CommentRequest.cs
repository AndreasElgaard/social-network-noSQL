using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers.Request
{
    public class CommentRequest
    {
        public string Text { get; set; }

        public ObjectId PostId { get; set; }

        public ObjectId UserId { get; set; }
    }
}
