using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DABAssignment3.Controllers.Request
{
    public class UserWallRequest
    {
        public string GuestId { get; set; }

        public string UserId { get; set; }
    }
}
