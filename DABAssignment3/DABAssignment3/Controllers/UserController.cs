using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DABAssignment3.Controllers.Request;
using DABAssignment3.Controllers.Response;
using DABAssignment3.Models;
using DABAssignment3.Models.Dto;
using DABAssignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DABAssignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        private readonly ICircleService _circleService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ICircleService circleService, IPostService postService)
        {
            _userservice = userService;
            _mapper = mapper;
            _circleService = circleService;
            _postService = postService;
        }
        // GET: api/User
        [HttpGet]
        public ActionResult<List<UserResponse>> Get()
        {
            var user = _userservice.GetAll();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<UserResponse>>(user));
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserResponse> Get(string id)
        {
            var user = _userservice.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserResponse>(user));
        }

        // POST: api/User
        [HttpPost("Post")]
        public IActionResult Post([FromBody] UserRequest request)
        {
            var user = _mapper.Map<User>(request);

            var result = _userservice.Create(user);

            return Ok(_mapper.Map<UserResponse>(user));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UserRequest request)
        {
            var user = _mapper.Map<User>(request);

            _userservice.Update(id, user);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _userservice.Remove(id);

            return Ok();
        }

        [HttpPut("Subscribe")]
        public IActionResult SubscribeToUser(string userId, string subscribeName)
        {
            var result =_userservice.SubsribeToUser(userId, subscribeName);

            return Ok(result);
        }

        [HttpPut("Block")]
        public IActionResult BlockUser(string userId, string blockId)
        {
            var result = _userservice.BlockUser(userId, blockId);

            return Ok(result);
        }

        [HttpPut("UnSubscriber")]
        public IActionResult UnSubscribeToUser(string userId, string subscribeName)
        {
            var result = _userservice.UnSubsribeToUser(userId, subscribeName);

            return Ok(result);
        }

        [HttpPut("UnblockUser")]
        public IActionResult UnBlockUser(string userId, string blockId)
        {
            var result = _userservice.UnBlockUser(userId, blockId);

            return Ok(result);
        }

        [HttpGet("Wall")]
        public IActionResult Wall(string UserId, string GuestId)
        {

            var userwall = _userservice.Get(UserId);

            var guest = _userservice.Get(GuestId);

            var wall = new WallResponse();

            if (userwall.BlockedUserId.Contains(guest.UserId.ToString()))
            {
                return BadRequest(new {Message = "This User has you blocked: " + userwall.Name});
            }

            foreach (var circleIds in userwall.CircleId)
            {
                var circle = _circleService.Get(circleIds);

                if (circle.UserId.Contains(guest.UserId.ToString()))
                {
                    foreach (var postId in circle.PostId)
                    {
                        var post = _postService.Get(postId);

                        if (post.UserId == userwall.UserId.ToString())
                        {
                            wall.Responses.Add(_mapper.Map<PostResponse>(post));
                        }
                    }
                }
            }

            foreach (var postId in userwall.PostId)
            {
                var post = _postService.Get(postId);

                if (post.Public)
                {
                    wall.Responses.Add(_mapper.Map<PostResponse>(post));
                }
            }
            
            return Ok(wall);
        }

        //Post all sample data
        [HttpPost("Post Sample Data")]
        public IActionResult PostSampleData()
        {
            User u1 = new User("Mads Jørgensen", 12, "Female");
            User u2 = new User("Mathias Pedersen", 17,"Male");
            User u3 = new User("Andres Ellegaard Sørensen", 22, "Male");
            User u4 = new User("Mark Højer Hansen", 23, "Male");
            User u5 = new User("Bjarne Benjaminsen Vølund", 28,"Female");

            Circle circle1 = new Circle("ørken");
            Circle circle2 = new Circle("CS:GO");
            Circle circle3 = new Circle("LOL");

            _circleService.Create(circle1);
            _circleService.Create(circle2);
            _circleService.Create(circle3);

            u1.CircleId.Add(circle1.CircleId.ToString());
            u2.CircleId.Add(circle1.CircleId.ToString());
            u3.CircleId.Add(circle1.CircleId.ToString());
            u4.CircleId.Add(circle1.CircleId.ToString());
            u1.CircleId.Add(circle2.CircleId.ToString());
            u2.CircleId.Add(circle2.CircleId.ToString());
            u4.CircleId.Add(circle2.CircleId.ToString());
            u5.CircleId.Add(circle2.CircleId.ToString());
            u1.CircleId.Add(circle3.CircleId.ToString());
            u2.CircleId.Add(circle3.CircleId.ToString());
            u3.CircleId.Add(circle3.CircleId.ToString());

            _userservice.Create(u1);
            _userservice.Create(u2);
            _userservice.Create(u3);
            _userservice.Create(u4);
            _userservice.Create(u5);

            circle1.UserId.Add(u1.UserId.ToString());
            circle1.UserId.Add(u2.UserId.ToString());
            circle1.UserId.Add(u3.UserId.ToString());
            circle1.UserId.Add(u4.UserId.ToString());
            circle2.UserId.Add(u1.UserId.ToString());
            circle2.UserId.Add(u2.UserId.ToString());
            circle2.UserId.Add(u5.UserId.ToString());
            circle2.UserId.Add(u4.UserId.ToString());
            circle3.UserId.Add(u1.UserId.ToString());
            circle3.UserId.Add(u2.UserId.ToString());
            circle3.UserId.Add(u3.UserId.ToString());
            circle3.UserId.Add(u5.UserId.ToString());

            _circleService.Update(circle1.CircleId.ToString(),circle1);
            _circleService.Update(circle2.CircleId.ToString(), circle2);
            _circleService.Update(circle3.CircleId.ToString(), circle3);



            return Ok();
        }
    }
}
