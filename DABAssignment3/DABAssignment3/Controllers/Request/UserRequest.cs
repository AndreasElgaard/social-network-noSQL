using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DABAssignment3.Controllers.Request
{
    public class UserRequest
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
    }
}
