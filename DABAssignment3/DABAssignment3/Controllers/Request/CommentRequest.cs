using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers.Request
{
    public class CommentRequest
    {
        public string CommentId { get; set; }

        public string Text { get; set; }

        public string PostId { get; set; }

        public string UserId { get; set; }
    }
}
