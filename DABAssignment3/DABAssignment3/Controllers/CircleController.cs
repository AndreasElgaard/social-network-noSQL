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

namespace DABAssignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly ICircleService _CircleService;
        private readonly IMapper _mapper;

        public CircleController(CircleService circleService, IMapper mapper)
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
        public ActionResult<CircleResponse> Get(string id)
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
        public IActionResult Put(string id, [FromBody] CircleRequest request)
        {
            var circle = _mapper.Map<Circle>(request);

            _CircleService.Update(id, circle);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _CircleService.Remove(id);

            return Ok();
        }

        // DELETE: api/RemoveUser
        [HttpDelete]
        public IActionResult RemoveUser(string userId, string circleId)
        {
            _CircleService.RemoveUserFromCicrle(userId, circleId);

            return Ok();
        }

        [HttpPut]
        public IActionResult AddUser(string userId, string circleId)
        {
            _CircleService.AddUserToCircle(userId, circleId);

            return Ok();
        }
    }
}
