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

namespace DABAssignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        private readonly ICircleService _circleService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ICircleService circleService)
        {
            _userservice = userService;
            _mapper = mapper;
            _circleService = circleService;
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
                return 
            }

            foreach (var circle in userwall.CircleId)
            {

            }






            return
        }
    }
}
