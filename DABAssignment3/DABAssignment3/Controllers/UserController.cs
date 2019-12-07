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

        [HttpPut]
        public IActionResult SubscribeToUser(string userId, string subscribeName)
        {
            var result =_userservice.SubsribeToUser(userId, subscribeName);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult BlockUser(string userId, string blockId)
        {
            var result = _userservice.BlockUser(userId, blockId);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult UnSubscribeToUser(string userId, string subscribeName)
        {
            var result = _userservice.UnSubsribeToUser(userId, subscribeName);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult UnBlockUser(string userId, string blockId)
        {
            var result = _userservice.UnBlockUser(userId, blockId);

            return Ok(result);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Feed(string userid)
        {
            var _feed = new FeedResponse();
            var userFeed = _userservice.FindByName(userid);

            //if user does not exits 
            if (userFeed == null)
            {
                return BadRequest(new {message = "UserId does not exist"}); 
            }


            //Find all subscribers and show their posts on feed wall
            foreach (var subscriber in userFeed.SubscriberId)
            {
                var provider = _userservice.Get(userFeed.UserId.ToString());
                if (provider.BlockedUserId.Contains(userFeed.UserId.ToString()))
                {
                    continue;
                }

                var circle = _circleService.Get(subscriber);
                var subscriberid = userFeed.SubscriberId;
                for (int i = 0; i < 6; i++)
                {
                    _feed.FeedResponses.Add(circle.PostId[circle.PostId.Count - i]);
                }
            }
        }
    }
}
