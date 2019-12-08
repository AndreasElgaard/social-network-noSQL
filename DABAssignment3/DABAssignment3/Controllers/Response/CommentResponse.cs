using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DABAssignment3.Controllers.Response
{
    public class CommentResponse
    {
        public string Text { get; set; }

        public string PostId { get; set; }

        public string UserId { get; set; }
    }
}
