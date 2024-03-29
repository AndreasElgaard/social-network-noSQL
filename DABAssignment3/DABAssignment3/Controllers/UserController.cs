﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using DABAssignment3.Controllers.Request;
using DABAssignment3.Controllers.Response;
using DABAssignment3.Models;
using DABAssignment3.Models.Dto;
using DABAssignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        private readonly ICommentService _commentservice;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ICircleService circleService, IPostService postService, ICommentService commentservice)
        {
            _userservice = userService;
            _mapper = mapper;
            _circleService = circleService;
            _postService = postService;
            _commentservice = commentservice;
        }
        // GET: api/User
        [HttpGet("GetAll")]
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

            return Ok(_mapper.Map<UserResponse>(result));
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
        public IActionResult SubscribeToUser(string userName, string subscribeName)
        {
            var result =_userservice.SubsribeToUser(userName, subscribeName);

            return Ok(result);
        }

        [HttpPut("Block")]
        public IActionResult BlockUser(string userName, string blockName)
        {
            var result = _userservice.BlockUser(userName, blockName);

            return Ok(result);
        }

        [HttpPut("UnSubscriber")]
        public IActionResult UnSubscribeToUser(string userName, string subscribeName)
        {
            var result = _userservice.UnSubsribeToUser(userName, subscribeName);

            return Ok(result);
        }

        [HttpPut("UnblockUser")]
        public IActionResult UnBlockUser(string userName, string blockName)
        {
            var result = _userservice.UnBlockUser(userName, blockName);

            return Ok(result);
        }

        [HttpPost("Wall")]
        public IActionResult Wall(UserWallRequest request)
        {

            var userwall = _userservice.FindByName(request.UserName);

            var guest = _userservice.FindByName(request.GuestName);

            var wall = new WallResponse();

            if (userwall.BlockedUserId.Contains(guest.UserId))
            {
                return BadRequest(new {Message = "This User has you blocked: " + userwall.Name});
            }

            foreach (var circleIds in userwall.CircleId)
            {
                var circle = _circleService.Get(circleIds);

                if (circle.UserId.Contains(guest.UserId))
                {
                    foreach (var postId in circle.PostId)
                    {
                        var post = _postService.Get(postId);

                        if (post.UserId == userwall.UserId)
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
            
            return Ok(wall.Responses);
        }

        [HttpGet("Feed")]
        public IActionResult Feed(string Username)
        {

            var _feed = new FeedResponse();
            var userFeed = _userservice.FindByName(Username);

            //if user does not exits 
            if (userFeed == null)
            {
                return BadRequest(new { message = "UserId does not exist" });
            }

            foreach (var postid in userFeed.PostId)
            {
                var posts = _postService.Get(postid);

                _feed.FeedResponses.Add(_mapper.Map<PostResponse>(posts));
            }

            if (userFeed.SubscriberId != null)
            {
                foreach (var subId in userFeed.SubscriberId)
                {
                    var provider = _userservice.Get(subId);
                    if (provider.BlockedUserId.Contains(userFeed.UserId))
                    {
                        continue;
                    }

                    foreach (var postid in provider.PostId)
                    {
                        var subposts = _postService.Get(postid);

                        if (subposts.Public)
                        {
                            _feed.FeedResponses.Add(_mapper.Map<PostResponse>(subposts));
                        }
                    }
                }
            }

            foreach (var circleid in userFeed.CircleId)
            {
                var circle = _circleService.Get(circleid);

                foreach (var postid in circle.PostId)
                {
                    var circleposts = _postService.Get(postid);

                    _feed.FeedResponses.Add(_mapper.Map<PostResponse>(circleposts));
                }
            }


            return Ok(_feed.FeedResponses);
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

            

            //u1.CircleId.Add(circle1.CircleId);
            //u2.CircleId.Add(circle1.CircleId);
            //u3.CircleId.Add(circle1.CircleId);
            //u4.CircleId.Add(circle1.CircleId);
            //u1.CircleId.Add(circle2.CircleId);
            //u2.CircleId.Add(circle2.CircleId);
            //u4.CircleId.Add(circle2.CircleId);
            //u5.CircleId.Add(circle2.CircleId);
            //u1.CircleId.Add(circle3.CircleId);
            //u2.CircleId.Add(circle3.CircleId);
            //u3.CircleId.Add(circle3.CircleId);

            _userservice.Create(u1);
            _userservice.Create(u2);
            _userservice.Create(u3);
            _userservice.Create(u4);
            _userservice.Create(u5);

            circle1.UserId.Add(u1.UserId);
            circle1.UserId.Add(u2.UserId);
            circle1.UserId.Add(u3.UserId);
            circle1.UserId.Add(u4.UserId);
            circle2.UserId.Add(u1.UserId);
            circle2.UserId.Add(u2.UserId);
            circle2.UserId.Add(u5.UserId);
            circle2.UserId.Add(u4.UserId);
            circle3.UserId.Add(u1.UserId);
            circle3.UserId.Add(u2.UserId);
            circle3.UserId.Add(u3.UserId);
            circle3.UserId.Add(u5.UserId);

            //_circleService.Update(circle1.CircleId,circle1);
            //_circleService.Update(circle2.CircleId, circle2);
            //_circleService.Update(circle3.CircleId, circle3);

            _circleService.Create(circle1);
            _circleService.Create(circle2);
            _circleService.Create(circle3);

            Post post1 = new Post("","Hold da op, man får slupret noget energidrik i sig under sådan en aflevering", 
                false, circle1.CircleId,u1.UserId);
            Post post2 = new Post("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.bonnier.cloud%2Ffiles%2Fill%2Fproduction%2F2014%2F05%2F07104857%2Fdesert3.jpg%3Fauto%3Dcompress%26fm%3Dpjpg%26fit%3Dmax%26fp-x%3D0.5%26fp-y%3D0.5%26w%3D1920%26ixlib%3Djs-1.2.0&f=1&nofb=1", 
                "Ude godt, hjemme bedst", false, circle1.CircleId, u4.UserId);
            Post post3 = new Post("", "Er kongen i top", 
                false, circle3.CircleId, u3.UserId);
            Post post4 = new Post("", "ez game, især mod mads", 
                false, circle2.CircleId, u2.UserId);
            Post post5 = new Post("https://tinyurl.com/vyj7l8v", "",
                false, circle3.CircleId, u5.UserId);

            _postService.Create(post1);
            _postService.Create(post2);
            _postService.Create(post3);
            _postService.Create(post4);
            _postService.Create(post5);

            Comment c1 = new Comment("Gå hjem",post1.PostId,u2.UserId);
            Comment c2 = new Comment("Savner det", post2.PostId, u1.UserId);
            Comment c3 = new Comment("Nej, det er jo mig", post3.PostId, u5.UserId);
            Comment c4 = new Comment("Ikke fair, du blev carried", post4.PostId, u1.UserId);
            Comment c5 = new Comment("Du er så ringe", post5.PostId, u5.UserId);
            Comment c6 = new Comment("Det har bare at være monster", post1.PostId, u4.UserId);

            _commentservice.Create(c1);
            _commentservice.Create(c2);
            _commentservice.Create(c3);
            _commentservice.Create(c4);
            _commentservice.Create(c5);
            _commentservice.Create(c6);

            post1.CommentId.Add(c1.CommentId);
            post2.CommentId.Add(c2.CommentId);
            post3.CommentId.Add(c3.CommentId);
            post4.CommentId.Add(c4.CommentId);
            post5.CommentId.Add(c5.CommentId);
            post1.CommentId.Add(c6.CommentId);

            circle1.PostId.Add(post1.PostId);
            circle1.PostId.Add(post2.PostId);
            circle3.PostId.Add(post3.PostId);
            circle2.PostId.Add(post4.PostId);
            circle3.PostId.Add(post5.PostId);

            //_circleService.Update(circle1.CircleId, circle1);
            //_circleService.Update(circle2.CircleId, circle2);
            //_circleService.Update(circle3.CircleId, circle3);


            Post publicpost = new Post("Det her er en Public post, den kan Benjamin ikke se", "",
                true, "", u1.UserId);
            Post publicpost2 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);

            Post publicpost3 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);
            Post publicpost4 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);
            Post publicpost5 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);
            Post publicpost6 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);
            Post publicpost7 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);
            Post publicpost8 = new Post("Det her er en Public post, den kan Mathias godt se", "",
                true, "", u3.UserId);

            _postService.Create(publicpost);
            _postService.Create(publicpost2);
            _postService.Create(publicpost3);
            _postService.Create(publicpost4);
            _postService.Create(publicpost5);
            _postService.Create(publicpost6);
            _postService.Create(publicpost7);
            _postService.Create(publicpost8);

            u1.PostId.Add(publicpost3.PostId);
            u2.PostId.Add(publicpost4.PostId);
            u3.PostId.Add(publicpost5.PostId);
            u4.PostId.Add(publicpost6.PostId);
            u5.PostId.Add(publicpost8.PostId);

            _circleService.Update(circle1.CircleId, circle1);
            _circleService.Update(circle2.CircleId, circle2);
            _circleService.Update(circle3.CircleId, circle3);

            //_circleService.Create(circle1);
            //_circleService.Create(circle2);
            //_circleService.Create(circle3);

            u1.CircleId.Add(circle1.CircleId);
            u2.CircleId.Add(circle1.CircleId);
            u3.CircleId.Add(circle1.CircleId);
            u4.CircleId.Add(circle1.CircleId);
            u1.CircleId.Add(circle2.CircleId);
            u2.CircleId.Add(circle2.CircleId);
            u4.CircleId.Add(circle2.CircleId);
            u5.CircleId.Add(circle2.CircleId);
            u1.CircleId.Add(circle3.CircleId);
            u2.CircleId.Add(circle3.CircleId);
            u3.CircleId.Add(circle3.CircleId);

            _userservice.Update(u1.UserId, u1);
            _userservice.Update(u2.UserId, u2);
            _userservice.Update(u3.UserId, u3);
            _userservice.Update(u4.UserId, u4);
            _userservice.Update(u5.UserId, u5);


            return Ok();
        }
    }
}
