using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DABAssignment3.Controllers.Request;
using DABAssignment3.Controllers.Response;
using DABAssignment3.Models;
using DABAssignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DABAssignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly ICircleService _CircleService;
        private readonly IMapper _mapper;

        public CircleController(ICircleService circleService, IMapper mapper)
        {
            _CircleService = circleService;
            _mapper = mapper;
        }
        // GET: api/Circle
        [HttpGet]
        public ActionResult<List<CircleRequest>> Get()
        {
            var circle = _CircleService.GetAll();

            if (circle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CircleResponse>>(circle));
        }

        // GET: api/Circle/5
        [HttpGet("{id}")]
        public ActionResult<CircleResponse> Get(ObjectId id)
        {
            var circle = _CircleService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CircleResponse>(circle));
        }

        // POST: api/Circle
        [HttpPost]
        public IActionResult Post([FromBody] CircleRequest request)
        {
            var circle = _mapper.Map<Circle>(request);

            var result = _CircleService.Create(circle);

            return Ok(_mapper.Map<CircleResponse>(result));
        }

        // PUT: api/Circle/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CircleRequest request)
        {
            var circle = _mapper.Map<Circle>(request);

            _CircleService.Update(request.CircleId, circle);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(ObjectId id)
        {
            _CircleService.Remove(id);

            return Ok();
        }

        // DELETE: api/RemoveUser
        [HttpDelete("RemoveUser")]
        public IActionResult RemoveUser([FromBody] CircleUserRequest request)
        {
            _CircleService.RemoveUserFromCicrle(request.UserId, request.CircleId);

            return Ok();
        }

        [HttpPut("AddUser")]
        public IActionResult AddUser([FromBody] CircleUserRequest request)
        {
            _CircleService.AddUserToCircle(request.UserId, request.CircleId);

            return Ok();
        }
    }
}
